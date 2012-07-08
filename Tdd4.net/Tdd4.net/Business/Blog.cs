using System;
using System.Collections.Generic;
using System.Linq;

namespace Tdd4.net.Business
{
    public class Blog : IBlog
    {
        private readonly List<Post> posts = new List<Post>();

        public IEnumerable<Post> GetPosts(Func<object, bool> func)
        {
            return posts.Where(p => func(p)).ToList();
        }

        public void AddPosts(IEnumerable<Post> posts)
        {
            this.posts.AddRange(posts);
        }
    }
}