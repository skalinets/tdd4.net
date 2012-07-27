using System;
using System.Collections.Generic;

namespace Tdd4.net.Business
{
    public interface IBlog
    {
        IEnumerable<Post> GetPosts(Func<object, bool> func);
        void AddPosts(IEnumerable<Post> posts);
        void RemovePostById(Guid id);
    }
}