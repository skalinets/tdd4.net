using Tdd4.net.Business;

namespace Tdd4.net.Features.Home
{
    public class HomeController
    {
        private readonly IBlog blog;

        public HomeController(IBlog blog)
        {
            this.blog = blog;
        }

        public AllPostsModel Items(PostFilter model)
        {
            return new AllPostsModel("Hello", blog.GetPosts(p => true));
        }
    }

    namespace Add
    {
    }
}