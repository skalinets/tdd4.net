using System;
using System.Collections.Generic;
using System.Linq;

namespace Tdd4.net.Business
{
    public class Blog : IBlog
    {
        private readonly List<Post> posts = new List<Post>();

        public Blog()
        {
            this.posts.AddRange(4.Times(i => GetRandomPost()));
        }

        private static Post GetRandomPost()
        {
            return new Post
                       {
                           Title = "title " + Guid.NewGuid(),
                           Body = "this is random body " + Guid.NewGuid()
                       };
        }

        public IEnumerable<Post> GetPosts(Func<object, bool> func)
        {
            return posts.Where(p => func(p)).ToList();
        }

        public void AddPosts(IEnumerable<Post> posts)
        {
            this.posts.AddRange(posts);
        }

        public void RemovePostById(Guid id)
        {
            posts.Remove(posts.First(p => p.Id == id));

        }
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Times<T>(this int number, Func<int, T> generator)
        {
            return Enumerable.Range(1, number).Select(generator);
        }
    }

}