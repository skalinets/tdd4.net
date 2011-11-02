using System.Collections.Generic;
using System.Linq;
using Site.DAL;
using Site.Models;

namespace Site.Controllers
{
    public static class PostExtensions
    {
        public static IEnumerable<Post> FilterDrafts(this IEnumerable<Post> posts)
        {
            var isAdmin = AuthorizationHelper.IsAdmin;
            return posts.Where(p => !p.IsDraft || isAdmin);
        }
    }
}