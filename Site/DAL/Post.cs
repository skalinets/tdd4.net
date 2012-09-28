using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Site.DAL
{
    public partial class Post
    {
        private readonly string[] briefDelimiters = new []{"<!--more-->", "[|more|]"};

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
            return briefDelimiters.Max(value => DisplayText.IndexOf(value, StringComparison.Ordinal));
        }

        public bool HasMoreTag { get { return GetIndicatorPosition() > -1; } }

        public string DisplayText
        {
            get
            {
                var tt = Text.Split("[[code]")
                    .Select(s =>
                                    {
                                        var items = s.Split("[code]]");
                                        if (items.Count() == 1)
                                        {
                                            return items[0];
                                        }
                                        return String.Join("[code]]", new[]
                                                   {
                                                       items[0]
                                                           .Replace("<p>", "")
                                                           .Replace("</p>", ""),
                                                       items[1]
                                                   });
                                    });
                                        string result = String.Join("[[code]", tt);

                result = result
                    .Replace("[[code]", CodePrefix)
                    .Replace("[code]]", CodeSuffix)
                    .Replace("<span style=\"white-space: pre;\"> ", "\t")
                    .Replace("</span>", "");

                result = result.Replace(briefDelimiters[1], briefDelimiters[0]);

                return result;
            }
        }

        public const string CodeSuffix = @"</pre>";
        public const string CodePrefix = @"<pre class=""brush: csharp;"">";
    }

    public static class StringExtensions
    {
        public static string[] Split(this string s, string delimiter)
        {
            return s.Split(new[] {delimiter}, StringSplitOptions.None);
        }
    }

}