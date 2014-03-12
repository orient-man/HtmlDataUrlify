using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace HtmlDataUrlify.Tests
{
    [TestFixture]
    public class DataUrlifyTests
    {
        private const string BasePath = @"..\..\..\HtmlDataUrlify.Tests\";

        public const string TestPageNoImages = BasePath + "TestPageNoImages.html";

        private readonly DataUrlify tool = new DataUrlify();

        [Test]
        public void NoChangesWhenNoImages()
        {
            tool.Urlify(TestPageNoImages)
                .Should()
                .Be(File.ReadAllText(TestPageNoImages));
        }
    }
}
