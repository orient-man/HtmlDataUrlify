using System;
using System.IO;
using System.Linq;
using HtmlAgilityPack;

namespace HtmlDataUrlify
{
    public class DataUrlify
    {
        public string Urlify(string filePath)
        {
            var doc = new HtmlDocument();
            var html = File.ReadAllText(filePath);
            doc.LoadHtml(html);
            var imgTags = doc.DocumentNode.SelectNodes("//img");
            if (imgTags == null || imgTags.Count == 0)
                return html;

            var rootPath = Path.GetDirectoryName(filePath) ?? "./";
            foreach (var tag in imgTags)
            {
                var src = tag.Attributes.FirstOrDefault(o => o.Name == "src");
                if (src != null)
                {
                    tag.SetAttributeValue(
                        "src",
                        GetDataUrl(Path.Combine(rootPath, src.Value)));
                }
            }
            return doc.DocumentNode.InnerHtml;
        }

        private static string GetDataUrl(string imgFile)
        {
            return
                "data:image/"
                + (Path.GetExtension(imgFile) ?? "").Replace(".", "")
                + ";base64,"
                + Convert.ToBase64String(File.ReadAllBytes(imgFile));
        }
    }
}