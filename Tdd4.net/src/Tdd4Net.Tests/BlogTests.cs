using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
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
            // arrange 
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

    public class PostTests
    {
        [Fact]
        public void should_provide_image_url()
        {
            // arrange
            var id = Guid.NewGuid();
//            var post = new Post {Image = new byte[] {1, 2}, Id = id};

            // act
//            var imageUrl = post.ImageUrl;
//
//            // assert
//            imageUrl.Should().Be("s/" + id);
        }
    }

    public class ImageUlrTester
    {
        [Fact]
        public void should_return_image_data_by_post_id()
        {
            // arrange
            var handler = new Tdd4.net.Features.S.GetHandler();

            // act
            var id = Guid.NewGuid().ToString();
//            handler.Execute(model: new FubuImageModel{Url = id.ToString())

            // assert
        }
    }

    public class GithubProviderTester
    {
        [Fact]
        public void should_get_text_from_github()
        {
            var githubProvider = new GithubProvider();

            string result = githubProvider.GetText("first-post").Result;

            result.Should().Contain("this is my");
        }
    }

    public class GithubProvider
    {
        public async Task<string> GetText(string postId)
        {
            var webClient = new WebClient();
            return await webClient.DownloadStringTaskAsync(new Uri("https://raw.github.com/skalinets/tdd4net.posts/master/posts/" + postId + ".md")); 
        }
    }
}
