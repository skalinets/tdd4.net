using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Site;
using Site.Controllers;
using Xunit;

namespace Site.Tests.Controllers
{
    public class HomeControllerTest
    {
//        [TestMethod]
//        public void Index()
//        {
            // Arrange
//            HomeController controller = new HomeController();
//
            // Act
//            ViewResult result = controller.Index() as ViewResult;
//
            // Assert
//            ViewDataDictionary viewData = result.ViewData;
//            Assert.AreEqual("Welcome to ASP.NET MVC!", viewData["Message"]);
//        }

        [Fact]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }
    }

    public class MyTest
    {
        [Fact]
        public void FactMethodName()
        {
            MockRepository
                .GenerateStub<MyClass>()
                .Stub(c => c.Foo(null))
                .Return(null);

        }
    }


    public class MyClass
    {
        public int I { get; private set; }
        public virtual string Foo(string arg)
        {
            return null;
        }
    }

//    public class BlogControllerTests
//    {
//        [Fact]
//        public void Index()
//        {
//            var controller = new BlogController();
//
//            controller.Index() as ViewResult;
//        }
//    }
}
