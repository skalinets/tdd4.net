using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace Tdd4.Net.Core
{
    public class GithubProvider
    {
        private readonly string userName;
        private readonly string repoName;
        private readonly string branch;

        public GithubProvider(string userName, string repoName, string branch)
        {
            this.userName = userName;
            this.repoName = repoName;
            this.branch = branch;
        }

        public string GetText(string postId)
        {
            return DownloadString(GetFileRoot() + postId);
        }

        private object GetFileRoot()
        {
            return string.Format("https://raw.github.com/{0}/{1}/{2}/", userName, repoName, branch);
        }

        private string DownloadString(string newAddress)
        {
            using (var webClient = new WebClient())
            {
                return webClient.DownloadString(new Uri(newAddress));
            }
        }

        public IEnumerable<string> GetFiles(string path)
        {
            var directoryAddress = GetDirectoryRoot() + path;
            var filesPageContent = DownloadString(directoryAddress);
            var doc = new HtmlDocument();
            doc.LoadHtml(filesPageContent);
            var htmlNodeCollection = doc.DocumentNode.SelectNodes("//td[@class='content']//a");
            var hrefs = htmlNodeCollection.SelectMany(node => node.Attributes.Where(a => a.Name == "href").Select(a => a.Value));
            var files = hrefs.Select(link => Regex.Match(link, @"/(?<filename>(\w|-|_|\s)+)\.mb$").Groups["filename"].Value)
                           .ToList();
            return files;
        }

        private  string GetDirectoryRoot()
        {
            return string.Format("https://github.com/{0}/{1}/tree/{2}/", userName, repoName, branch);
        }
    }
}