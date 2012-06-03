namespace Tdd4.net.Features.Home
{
    public class GetHandler
    {
        public OutModel Execute()
        {
            return new OutModel("Hello");
        }
    }

    public class OutModel
    {
        public OutModel(string message)
        {
            this.Message = message;
        }

        public string Message { get; private set; }
    }
}