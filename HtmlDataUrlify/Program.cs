using System;

namespace HtmlDataUrlify
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(new DataUrlify().Urlify(args[0]));
        }
    }
}