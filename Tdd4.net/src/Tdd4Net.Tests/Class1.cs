using System.Text;
using FizzWare.NBuilder;
using FluentAssertions;
using Tdd4.net.Business;
using Xunit;

namespace Tdd4Net.Tests
{
    public class PostListAggregateTests
    {
        [Fact]
        public void should_return_posts_after_add()
        {
            // arrange 
            var aggregate = new Blog();
            var initialPosts = Builder<Post>.CreateListOfSize(1)
                .All()
                .Build();
            aggregate.AddPosts(initialPosts);

            // act
            var posts = aggregate.GetPosts(p => true);

            // assert
            posts.Should().Equal(initialPosts);
        }
    }
}
