using Tdd4.net.Business;

namespace Tdd4.net.Features.Home
{
    public class GetHandler
    {
        private readonly IBlog blog;

        public GetHandler(IBlog blog)
        {
            this.blog = blog;
        }

        public AllPostsModel Execute(PostFilter model)
        {
            return new AllPostsModel("Hello", blog.GetPosts(p => true));
        }
    }

    namespace Add
    {
    }
}