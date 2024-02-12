using Forum_App.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Forum_App.Data
{
    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            : base(options)    
        {
        }
        public DbSet<Post> Posts { get; set; }
    }
}
