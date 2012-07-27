using Tdd4.net.Business;

namespace Tdd4.net.Features.Add
{
    public class GetHandler
    {
        public Post Execute(FooAddPost post)
        {
            return new Post();
        }
    }

    public class FooAddPost
    {
    }
}