using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using Tdd4.net.Business;
using Xunit;

namespace Tdd4Net.Tests
{
    public class BlogTests
    {
        private Blog blog;
        private IList<Post> initialPosts;

        public BlogTests()
        {
            blog = new Blog();
            initialPosts = Builder<Post>.CreateListOfSize(1)
                .All()
                .Build();
            blog.AddPosts(initialPosts);
        }

        [Fact]
        public void should_return_posts_after_add()
        {

            // act
            var posts = GetAllPosts();

            // assert
            posts.Should().Contain(initialPosts);
        }

        private IEnumerable<Post> GetAllPosts()
        {
            return blog.GetPosts(p => true);
        }

        [Fact]
        public void should_remove_post_by_id()
        {
            // act
            var post = initialPosts[0];
            blog.RemovePostById(post.Id);

            // assert
            GetAllPosts().Should().NotContain(post);
        }
    }

    public class GithubProviderTester
    {
        private readonly GithubProvider githubProvider;

        public GithubProviderTester()
        {
            githubProvider = new GithubProvider("https://raw.github.com/skalinets/tdd4net.posts/for-tests/");
        }

        [Fact]
        public void should_get_text_from_github()
        {
            var result = githubProvider.GetText("posts/test-post.mb");
            result.Should().Be("this is test post");
        }
    }

    public class GithubProvider
    {
        private readonly string root;

        public GithubProvider(string root)
        {
            this.root = root;
        }

        public string GetText(string postId)
        {
            var webClient = new WebClient();
            var address = root + postId;
            return webClient.DownloadString(new Uri(address)); 
        }
    }
}
