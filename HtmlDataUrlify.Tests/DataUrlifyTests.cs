using System.IO;
using System.Linq;
using FluentAssertions;
using HtmlAgilityPack;
using NUnit.Framework;

namespace HtmlDataUrlify.Tests
{
    [TestFixture]
    public class DataUrlifyTests
    {
        private const string BasePath = @"..\..\..\HtmlDataUrlify.Tests\";

        public const string TestPageNoImages = BasePath + "TestPageNoImages.html";
        public const string TestPage = BasePath + "TestPage.html";

        private readonly DataUrlify tool = new DataUrlify();

        [Test]
        public void NoChangesWhenNoImages()
        {
            tool.Urlify(TestPageNoImages)
                .Should()
                .Be(File.ReadAllText(TestPageNoImages));
        }

        [Test]
        public void ConvertsImgSourcesToDataUri()
        {
            // act
            var html = tool.Urlify(TestPage);

            // assert
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            doc.DocumentNode
                .SelectNodes("//img")
                .SelectMany(o => o.Attributes)
                .Where(o => o.Name == "src")
                .Select(o => o.Value)
                .First()
                .Should()
                .StartWith("data:image/jpg;base64,/9j/4AAQSkZJRgABAQEASABIAAD/");
        }

    }
}
