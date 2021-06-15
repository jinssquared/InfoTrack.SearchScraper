using InfoTrack.SearchScraper.API.Converters;
using InfoTrack.SearchScraper.API.Representations;
using Moq;
using NUnit.Framework;

namespace InfoTrack.SearchScraper.Tests.Converters
{
    [TestFixture]
    public class GoogleSearchConverterTest
    {
        private GoogleSearchConverter _converter;

        [SetUp]
        public void SetUp()
        {
            _converter = new GoogleSearchConverter();
        }

        [TestCase("this and that", "this+and+that")]
        public void Converts_spaces_to_pluses(string searchTerm, string expectedResult)
        {
            var searchRequestRepresentation = new SearchRequestRepresentation() { SearchTerm = searchTerm, UrlToMatch = It.IsAny<string>() };

            var result = _converter.Convert(searchRequestRepresentation);

            Assert.AreEqual(expectedResult, result.SearchTerm);
        }
    }
}
