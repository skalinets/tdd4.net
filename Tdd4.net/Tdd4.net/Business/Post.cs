using System;
using System.Web;
using FubuCore;

namespace Tdd4.net.Business
{
    public class Post
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public HttpPostedFileBase Image { get; set; }

        public string ImageDescription
        {
            get
            {
                return Image == null ? "no image" :
                                                      "Type: {0}; Length: {1}; Name: {2}".ToFormat(Image.ContentType, Image.FileName, Image.ContentLength);
            }
        }

        public Guid Id { get; set; }

        public string ImageUrl
        {
            get { return "s/" + Id; }
        }
    }
}