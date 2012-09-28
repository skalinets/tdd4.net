using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Site.DAL;
using Xunit;
using Xunit.Extensions;

namespace Site.Tests.Controllers
{
    public class PostsTests
    {
        [Theory]
        [PropertyData("Delimiters")]
        public void should_show_brief_content(string moreDelimiter)
        {
            // arrange
            const string expected = "short";
            var post = new Post {Text = expected + moreDelimiter + "long"};

            // act
            var actual = post.BriefText;

            // assert
            Assert.Equal(expected, actual);
            
        }

        [Fact]
        public void brief_text_should_be_the_same_as_regula_text()
        {
            // arrange
            var post = new Post {Text = "this is mytext"};

            // act & assert
            post.BriefText.Should().Be(post.Text);
        }

        [Theory]
        [PropertyData("Delimiters")]
        public void brief_text_should_support_code_formatting(string moreDelimiter)
        {
            // arrange
            var post = new Post {Text = "test [[code] code [code]] end [|more|] the end"};

            // act
            var briefText = post.BriefText;

            // assert
            briefText.Should().Be("test " + Post.CodePrefix + " code " + Post.CodeSuffix + " end ");

        }

        [Fact]
        public void display_text_should_not_contain_more_delimiter()
        {
            // arrange
            var moreDelimiter = "[|more|]";
            var post = new Post {Text = "text" + moreDelimiter + "another text"};

            // act
            var text = post.DisplayText;

            // assert
            text.Should().NotContain(moreDelimiter);
        }

        public static IEnumerable<object[]> Delimiters
        {
            get { return new[] {"<!--more-->", "[|more|]"}.Select(i => new[] {i}).ToArray(); }
        }

        [Fact]
        public void formatted_text_should_display_cs_code()
        {
            // arrange
            var post = new Post {Text = "[[code]this is my code[code]]"};

            // act
            var displayText = post.DisplayText;

            // assert
            displayText.Should().Be(Post.CodePrefix + @"this is my code" + Post.CodeSuffix);
        }

        [Fact]
        public void paragraphs_in_code_should_be_removed()
        {
            // arrange
            var post = new Post {Text = "<p>[[code]void foo</p>\n<p><span style=\"white-space: pre;\"> </span>void Boo() {}</p>\n<p>}[code]]</p>"};

            // act
            var displayText = post.DisplayText;

            // assert
            displayText.Should().Be("<p>" + Post.CodePrefix + "void foo\n\tvoid Boo() {}\n}" + Post.CodeSuffix + "</p>");
        }

        [Fact]
        public void paragraphs_in_text_should_not_be_removed()
        {
            // arrange
            var text = "<p>this is text</p><p>with paragraphs</p>";
            var post = new Post {Text = text};

            // act
            var displayText = post.DisplayText;

            // assert
            displayText.Should().Be(text);
        }
    }
}