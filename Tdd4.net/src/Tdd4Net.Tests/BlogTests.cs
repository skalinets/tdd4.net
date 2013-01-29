using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using AutofacContrib.NSubstitute;
using FizzWare.NBuilder;
using FluentAssertions;
using HtmlAgilityPack;
using StructureMap;
using StructureMap.AutoMocking;
using StructureMap.AutoMocking.NSubstitute;
using Tdd4.net.Business;
using Tdd4.net.Features.Home;
using Xunit;
using NSubstitute;

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

        [Fact]
        public void should_get_text_from_github()
        {
            var result = githubProvider.GetText("posts/test-post.mb");
            result.Should().Be("this is test post");
        }

        [Fact]
        public void should_get_folder_content()
        {
            githubProvider.GetFiles("posts")
                .Should()
                .BeEquivalentTo(new[] {"test-post", "another-post"});
        }
    }

    public class GithubProvider
    {
        private readonly string userName;
        private readonly string repoName;
        private readonly string branch;

        public GithubProvider(string userName, string repoName, string branch)
        {
            this.userName = userName;
            this.repoName = repoName;
            this.branch = branch;

        }

        public string GetText(string postId)
        {
            return DownloadString(GetFileRoot() + postId);
        }

        private object GetFileRoot()
        {
            return string.Format("https://raw.github.com/{0}/{1}/{2}/", userName, repoName, branch);
        }

        private string DownloadString(string newAddress)
        {
            using (var webClient = new WebClient())
            {
                return webClient.DownloadString(new Uri(newAddress));
            }
        }

        public IEnumerable<string> GetFiles(string path)
        {
            var directoryAddress = GetDirectoryRoot() + path;
            var filesPageContent = DownloadString(directoryAddress);
            var doc = new HtmlDocument();
            doc.LoadHtml(filesPageContent);
            var files = doc.DocumentNode
                .SelectNodes("//td[@class='content']/a")
                .SelectMany(node => node.Attributes.Where(a => a.Name == "href")
                    .Select(a => a.Value))
                    .Select(link => Regex.Match(link, @"/(?<filename>(\w|-|_|\s)+)\.mb$").Groups["filename"].Value)
                    .ToList();
            return files;
        }

        private  object GetDirectoryRoot()
        {
            return string.Format("https://github.com/{0}/{1}/tree/{2}/", userName, repoName, branch);
        }
    }
}
