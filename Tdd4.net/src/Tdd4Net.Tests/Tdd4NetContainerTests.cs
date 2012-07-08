using FluentAssertions;
using StructureMap;
using Tdd4.net.App_Start;
using Tdd4.net.Business;
using Xunit;

namespace Tdd4Net.Tests
{
    public class Tdd4NetContainerTests
    {
        private readonly IContainer container = ContainerFactory.Container();

        [Fact]
        public void PostListAggregate_shoud_not_be_null()
        {
            // act
            var aggregate = container.GetInstance<IBlog>();

            // assert
            aggregate.Should().NotBeNull();
        }

        [Fact]
        public void PostListAggregate_should_be_singletone()
        {
            // arrange

            // act
            var instance1 = container.GetInstance<IBlog>();
            var instance2 = container.GetInstance<IBlog>();

            // assert
            instance1.Should()
                .BeSameAs(instance2);
        }

        [Fact]
        public void should_get_type_by_interface_using_default_conventions()
        {
            // act
            var instance = container.GetInstance<IBlog>();

            // assert
            instance.Should().BeOfType<Blog>();
        }
    }
}