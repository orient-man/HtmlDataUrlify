using System.IO;

namespace HtmlDataUrlify
{
    public class DataUrlify
    {
        public string Urlify(string path)
        {
            return File.ReadAllText(path);
        }
    }
}