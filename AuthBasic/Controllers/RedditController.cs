using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using AuthBasic.Data;
using AuthBasic.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace AuthBasic.Controllers
{
    public class RedditController : Controller
    {
        private readonly ILogger<RedditController> _logger;
        static readonly HttpClient client = new HttpClient();
        public RedditContext _context { get; set; }

        public RedditController(ILogger<RedditController> logger, RedditContext context)
        {
            _logger = logger;
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> r(string id)
        {
            System.Console.WriteLine("FUCK");
            RedditBackgroundShit rbs = new RedditBackgroundShit(_context);
            await rbs.Post(id);
            ViewData["subreddit"] = id;

            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> i(string id)
        {
            System.Console.WriteLine("FUCK");
            if (id != null)
            {
                ViewData["subreddit"] = id;
                return View("i");
            }
            else
            {
                return View("Categories");
            }
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment(RedditComment comment, string ReturnURL)
        {
            RedditPost post = await _context.Posts.FindAsync(comment.postID);
            post.num_comments += 1;

            Int64 unixTimestamp = (Int64)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            comment.unixTimestamp = unixTimestamp;
            await _context.AddAsync(comment);
            await _context.SaveChangesAsync();
            return LocalRedirect("/reddit/comments/" + comment.postID);
        }

        [Authorize]
        [HttpGet]
        private IActionResult CreateComment()
        {

            return PartialView("_createComment");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost([FromForm] RedditPost post)
        {
            System.Console.WriteLine("^^^^^^^^^^>>");
            System.Console.WriteLine(post.url);
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            post.created_utc = unixTimestamp;
            post.id = unixTimestamp.ToString();
            post.name = "t3_" + post.id;
            post.num_comments = 0;
            post.score = "0";
            await _context.AddAsync(post);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }

        public async Task<IActionResult> Comments(string id)
        {
            RedditPost post = await _context.Posts.FindAsync(id);
            post.created_string = SecondsToAgoString((Int64)post.created_utc);

            List<RedditComment> RList = _context.Comments
                .Where(a => a.postID == id)
                .ToList();
            RList.Reverse();

            string current_id = post.id;
            CommentTree commentTree = new CommentTree();
            commentTree.children = new List<CommentTree>();
            commentTree.comment = null;
            List<RedditComment> TopLevelComments = RList.Where(a => a.parentID.ToString() == current_id).ToList();
            foreach (var TopLevelComment in TopLevelComments)
            {
                CommentTree child_comment_tree = GetCommentTree(RList, TopLevelComment, true);
                commentTree.children.Add(child_comment_tree);
            }

            foreach (var item in RList)
            {
                item.createdString = SecondsToAgoString(item.unixTimestamp);
            }

            string subreddit = post.subreddit;

            CommentsPage commentsPage = new CommentsPage()
            {
                post = post,
                commentTree = commentTree
            };

            return View(commentsPage);
        }

        private CommentTree GetCommentTree(List<RedditComment> comments, RedditComment comment, bool parity)
        {
            List<RedditComment> children = comments.Where(child => child.parentID.ToString() == comment.id.ToString()).ToList();
            if (children.Count == 0)
            {
                comment.parity = parity;
                return new CommentTree() { children = null, comment = comment };
            }
            else
            {
                RedditComment whatcomment = comment;
                comment.parity = parity;
                CommentTree rt = new CommentTree()
                {
                    children = new List<CommentTree>(),
                    comment = whatcomment
                };
                List<CommentTree> what = new List<CommentTree>();
                foreach (var item in children)
                {
                    what.Add(GetCommentTree(comments, item, !parity));
                }
                rt.children = what;

                return rt;
            }
        }

        public ActionResult GetPosts(string subreddit)
        {
            var Posts = _context.Posts.Where(a => a.subreddit == subreddit).ToList();
            foreach (var post in Posts)
            {
                post.created_string = SecondsToAgoString((Int64)post.created_utc);

            }
            Posts = Posts.OrderByDescending(o => o.created_utc).ToList();
            return PartialView("_post", Posts);
        }

        public async Task<IActionResult> Images(string subreddit, string after, string t)
        {
            System.Console.WriteLine($"https://api.reddit.com/r/{subreddit}/top?after={after}&t={t}");
            string result = await Get($"https://api.reddit.com/r/{subreddit}/top?after={after}&t={t}&limit=5");
            List<RedditPost> something = JsonToObject(result);
            System.Console.WriteLine(something);
            return PartialView("_post", something);
        }

        private List<RedditPost> JsonToObject(string jsonString)
        {
            JObject json = JObject.Parse(jsonString)["data"].ToObject<JObject>();
            JArray arr = json["children"].ToObject<JArray>();
            List<RedditPost> l = new List<RedditPost>();
            for (int i = 0; i < arr.Count; i++)
            {
                var jsonString2 = arr[i]["data"].ToString();
                RedditPost redditPost = JsonConvert.DeserializeObject<RedditPost>(jsonString2);
                redditPost.created_string = SecondsToAgoString((Int64)redditPost.created_utc);
                l.Add(redditPost);
            }
            return l;
        }

        private string SecondsToAgoString(Int64 seconds)
        {
            Int64 unixTimeStamp = (Int64)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            Int64 timeDelta = unixTimeStamp - seconds;
            Int64 yearSeconds = 31536000;
            Int64 monthSeconds = 2592000;
            Int64 daySeconds = 86400;
            Int64 hourSeconds = 3600;
            Int64 minutesSeconds = 60;

            if (timeDelta > yearSeconds)
            {
                return $"{timeDelta / yearSeconds} years ago";
            }
            else if (timeDelta > monthSeconds)
            {
                return $"{timeDelta / monthSeconds} months ago";
            }
            else if (timeDelta > daySeconds)
            {
                return $"{timeDelta / daySeconds} days ago";
            }
            else if (timeDelta > hourSeconds)
            {
                return $"{timeDelta / hourSeconds} hours ago";
            }
            else if (timeDelta > minutesSeconds)
            {
                return $"{timeDelta / minutesSeconds} minutes ago";
            }
            else
            {
                return $"{timeDelta} seconds ago";
            }
        }

        static private async Task<string> Get(string url)
        {
            client.DefaultRequestHeaders.Add("User-Agent", "C# App");
            try
            {
                return await client.GetStringAsync(url);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }
    }
}