using System.Net;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Runtime;
using Tdd4.net.Business;
using Tdd4.net.Features.Add;
using Tdd4.net.Features.Home;

namespace Tdd4.net.Features.Remove
{
    public class RemovePostHandler
    {
        private readonly IBlog blog;

        public RemovePostHandler(IBlog blog)
        {
            this.blog = blog;
        }

        public FubuContinuation RemovePost(RemoveModel model)
        {
            blog.RemovePostById(model.PostIdToRemove);
            return FubuContinuation.RedirectTo(new PostFilter());
        }
    }
    
}

namespace Tdd4.net.Features.S
{
    public class GetHandler
    {
        public FubuContinuation Execute(FubuImageModel model)
        {
            IOutputWriter writer = new InMemoryOutputWriter();
//            writer.AppendHeader(HttpResponseHeader.ContentType, MimeType.);
            return FubuContinuation.EndWithStatusCode(HttpStatusCode.OK);
        }

        public class FubuImageModel
        {
            public string Url { get; set; }
        }
    }

}