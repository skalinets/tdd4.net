using System;
using System.Linq;
using Site.Models;
using Xunit;

namespace Site.Tests.Controllers
{
    public class PagerModelTests
    {
        [Fact]
        public void Items_CountIs5PageSizeIs2_ThereAre3Items()
        {
            var pagerModel = new PagerModel{ItemCount = 5, PageSize = 2};

            var items = pagerModel.Items;

            Assert.Equal(3, items.Count());
        }

        [Fact]
        public void Items_CountIs6PageSizeIs2_SecondItemIs2_3()
        {
            var pagerModel = new PagerModel{ItemCount = 6, PageSize = 2};

            var items = pagerModel.Items;

            var item = items.ElementAt(1);
            AssertPagerItem(item, 3, 2.ToString());
        }

        [Fact]
        public void Items_CountIs11PageSizeIs3_ThirdItemIs3_7()
        {
            var pagerModel = new PagerModel{ItemCount = 11, PageSize = 3};

            var items = pagerModel.Items;

            var item = items.ElementAt(2);
            AssertPagerItem(item, 7, 3.ToString());
        }

        [Fact]
        public void Items_CountIs4PageSizeIs2_ThereAre2Items()
        {
            var pagerModel = new PagerModel {ItemCount = 4, PageSize = 2};

            var items = pagerModel.Items;

            Assert.Equal(2, items.Count());
        }

        private void AssertPagerItem(Tuple<string, int> item, int expectedItemIndex, string expectedCaption)
        {
            Assert.Equal(expectedItemIndex, item.Item2);
            Assert.Equal(expectedCaption, item.Item1);
        }
    }
}