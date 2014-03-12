using System.IO;

namespace HtmlDataUrlify
{
    class Program
    {
        private static void Main(string[] args)
        {
            File.WriteAllText(args[1], new DataUrlify().Urlify(args[0]));
        }
    }
}