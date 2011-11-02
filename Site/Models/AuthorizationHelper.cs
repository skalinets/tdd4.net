using System.Web;

namespace Site.Models
{
    public class AuthorizationHelper
    {
        public static bool IsAdmin
        {
            get
            {
                var principal = HttpContext.Current.User;
                var identity = principal.Identity;
                return identity.IsAuthenticated && identity.Name == "serhiyk";
            }
        }
    }
}