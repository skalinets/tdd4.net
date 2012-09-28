﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

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
                                        string replace = String.Join("[[code]", tt);
//                                        Regex.Replace(Text, @"(\[\[code\].*)(<p>|</p>)(.*\[code\]\])", @"\1\3", RegexOptions.Multiline);

                replace = replace
                    .Replace("[[code]", CodePrefix)
                    .Replace("[code]]", CodeSuffix)
                    .Replace("<span style=\"white-space: pre;\"> ", "\t")
                    .Replace("</span>", "")
//                    .Replace("<p>", "")
//                    .Replace("</p>", "")
                    ;

                return replace;
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