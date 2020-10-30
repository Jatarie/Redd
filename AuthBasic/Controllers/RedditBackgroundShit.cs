using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AuthBasic.Data;
using AuthBasic.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AuthBasic
{
    public class RedditBackgroundShit
    {
        static readonly HttpClient client = new HttpClient();
        public RedditContext _context { get; set; }

        public RedditBackgroundShit(RedditContext context){
            _context = context;
        }
        
        public async Task Post(string subreddit)
        {
            string response = await Get($"https://api.reddit.com/r/{subreddit}");
            List<RedditPost> RList = JsonToObject(response);
            foreach (var item in RList)
            {
                if (await _context.FindAsync<RedditPost>(item.id) == null)
                {
                    await _context.AddAsync(item);
                    System.Console.WriteLine($"Adding: {item}");
                    await _context.SaveChangesAsync();
                }
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
    }

}