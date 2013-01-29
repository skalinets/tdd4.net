using System.Web;
using System.Web.Compilation;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Http;
using FubuMVC.Core.Runtime;

namespace Tdd4.net.Features
{
    public class RootAnchor
    {
    }

    namespace l
    {
        public class Get_id_Handler
        {
            private readonly IOutputWriter writer;
            private HttpResponseBase response;

            public Get_id_Handler(IOutputWriter writer, HttpContextBase context)
            {
                this.writer = writer;
                response = context.Response;
            }

            public byte[] Execute(ImageId id)
            {
                response.ContentType = MimeType.Text.ToString();
                return System.Text.Encoding.UTF8.GetBytes(id.Id);
            }

            public class ImageId
            {
                public string Id { get; set; }
            }
        }
    }
}