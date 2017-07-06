using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogBounty.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<TopicEntity> Topics { get; set; }
        public DbSet<TopicTagEntity> TopicTags { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<SubmissionEntity> Submissions { get; set; }
        public DbSet<UpvoteEntity> Upvotes { get; set; }
        public DbSet<CommentEntitiy> Comments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
