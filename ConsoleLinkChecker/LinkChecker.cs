using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace ConsoleLinkChecker
{
    public class LinkChecker
    {
        public static IEnumerable<string> GetLinks(string page)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(page);
            var links = htmlDocument.DocumentNode.SelectNodes("//a[@href]")
                            .Select(node => node.GetAttributeValue("href", string.Empty))
                            .Where(link => !String.IsNullOrEmpty(link))
                            .Where(link => link.StartsWith("http"));

            return links;
        }
    }
}