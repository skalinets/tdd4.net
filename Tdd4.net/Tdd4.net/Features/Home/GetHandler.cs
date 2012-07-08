using System.Collections.Generic;
using Tdd4.net.Business;

namespace Tdd4.net.Features.Home
{
    public class GetHandler
    {
        private readonly Blog blog;

        public GetHandler(Blog blog)
        {
            this.blog = blog;
        }

        public AllPostsModel Execute()
        {
            return new AllPostsModel("Hello", blog.GetPosts(p => true));
        }
    }

    public class AllPostsModel
    {
        public AllPostsModel(string message, IEnumerable<Post> posts)
        {
            this.Message = message;
            Posts = posts;
        }

        public string Message { get; private set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}