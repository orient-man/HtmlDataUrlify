using System.IO;
using HtmlAgilityPack;

namespace HtmlDataUrlify
{
    public class DataUrlify
    {
        public string Urlify(string path)
        {
            var doc = new HtmlDocument();
            var html = File.ReadAllText(path);
            doc.LoadHtml(html);
            var imgTags = doc.DocumentNode.SelectNodes("//img");
            if (imgTags == null || imgTags.Count == 0)
                return html;

            return doc.DocumentNode.InnerHtml;
        }
    }
}