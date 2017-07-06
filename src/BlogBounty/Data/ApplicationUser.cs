using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BlogBounty.Data
{
    // Add profile data for application users by adding properties to the User class
    public class ApplicationUser : IdentityUser
    {
        public List<UpvoteEntity> Upvotes { get; set; }
        public List<CommentEntity> Comments { get; set; }
    }
}
