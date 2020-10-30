using Microsoft.EntityFrameworkCore;
using AuthBasic.Models;

namespace AuthBasic.Data
{
    public class RedditContext : DbContext
    {
        public RedditContext (DbContextOptions<RedditContext> options)
            : base(options)
        {
        }
        public DbSet<RedditPost> Posts { get; set; }
        public DbSet<RedditComment> Comments { get; set; }
    }
}