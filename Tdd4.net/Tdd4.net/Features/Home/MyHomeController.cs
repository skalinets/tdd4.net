using System.Collections.Generic;
using FubuMVC.Core.Continuations;
using Tdd4.net.Business;

namespace Tdd4.net.Features.Home
{
    public class AllPostsModel
    {
        public AllPostsModel(string message, IEnumerable<Post> posts)
        {
            Message = message;
            Posts = posts;
        }

        public AllPostsModel()
        {
//            throw new System.NotImplementedException();
        }

        public string Message { get; private set; }
        public IEnumerable<Post> Posts { get; set; }

        public FubuContinuation RedirectTo { get; set; }
    }
}