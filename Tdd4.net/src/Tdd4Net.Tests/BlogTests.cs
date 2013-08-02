using System;
using System.Collections.Generic;
using System.Web;
using AutofacContrib.NSubstitute;
using FluentAssertions;
using Ploeh.AutoFixture;
using StructureMap;
using StructureMap.AutoMocking;
using StructureMap.AutoMocking.NSubstitute;
using Tdd4.Net.Core;
using Tdd4.net.Business;
using Tdd4.net.Features.Home;
using Xunit;
using NSubstitute;
using System.Linq;

namespace Tdd4Net.Tests
{
    public class BlogTests
    {
        private Blog blog;
        private IList<Post> initialPosts;

        public BlogTests()
        {
            blog = new Blog();
            var fixture = new Fixture();
            initialPosts = fixture.Build<Post>().With(p => p.Image, null).CreateMany().ToList();
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

    public class HomeHandlerTester
    {
        [Fact]
        public void should_return_all_posts()
        {
            var autoSubstitute = new AutoSubstitute();
            var post = new Post();
            autoSubstitute.Resolve<IBlog>().GetPosts(Arg.Is<Func<object, bool>>(f => f(post))).Returns(new[] { post });
            var handler = autoSubstitute.Resolve<HomeController>();
            handler.Items(null).Posts.Should().Equal(new[] {post});
        }
    }

    public class GithubProviderTester
    {
        private readonly GithubProvider githubProvider;

        public GithubProviderTester()
        {
            var userName = "skalinets";
            var branch = "for-tests";
            var repoName = "tdd4net.posts";
            githubProvider = new GithubProvider(userName, repoName, branch);
        }

        [Fact, Trait("Category", "Integration")]
        public void should_get_text_from_github()
        {
            var result = githubProvider.GetText("posts/test-post.mb");
            result.Should().Be("this is test post");
        }
         
        [Fact, Trait("Category", "Integration")]
        public void should_get_folder_content()
        {
            githubProvider.GetFiles("posts")
                .Should()
                .BeEquivalentTo(new[] {"test-post", "another-post"});
        }
    }
}
