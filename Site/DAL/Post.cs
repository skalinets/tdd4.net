using System;
using System.Linq;

namespace Site.DAL
{
    public partial class Post
    {
        public string BriefText
        {
            get
            {
                var indicatorPosition = GetIndicatorPosition();
                var shouldBeTruncated = indicatorPosition > -1;
                var displayText = DisplayText;
                return shouldBeTruncated ? displayText.Substring(0, indicatorPosition) : displayText;
            }
        }

        private int GetIndicatorPosition()
        {
            var values = new []{"<!--more-->", "[|more|]"};
            return values.Max(value => DisplayText.IndexOf(value, StringComparison.Ordinal));
        }

        public bool HasMoreTag { get { return GetIndicatorPosition() > -1; } }

        public string DisplayText
        {
            get
            {
                return Text
                    .Replace("[[code]", CodePrefix)
                    .Replace("[code]]", CodeSuffix)
                    .Replace("<span style=\"white-space: pre;\"> ", "\t")
                    .Replace("</span>", "")
                    .Replace("<p>", "")
                    .Replace("</p>", "");
            }
        }

        public const string CodeSuffix = @"</pre>";
        public const string CodePrefix = @"<pre class=""brush: csharp;"">";
    }
}