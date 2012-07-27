using System;
using FubuMVC.Core.Continuations;
using Tdd4.net.Business;
using Tdd4.net.Features.Home;

namespace Tdd4.net.Features.Add
{
    public class PostHandler
    {
        private readonly IBlog blog;

        public PostHandler(IBlog blog)
        {
            this.blog = blog;
        }

        public FubuContinuation Execute(Post post)
        {
            blog.AddPosts(new[] {post});
            if (post.Image == null)
            {
                throw new Exception("null");

            }
            return FubuContinuation.RedirectTo(new PostFilter());
        }
    }
}

namespace Tdd4.net.Features.Add.Remove
{
}