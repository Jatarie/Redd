using System.Collections.Generic;
using AuthBasic.Models;

namespace AuthBasic.Models{
    public class CommentTree{
        public RedditComment comment;
        public List<CommentTree> children;
    }
}