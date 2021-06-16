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
            var result = _converter.Convert(searchTerm);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
