using AngleSharp;
using AngleSharp.Dom;
using AutoFixture.NUnit3;
using InfoTrack.SearchScraper.API.Entities;
using InfoTrack.SearchScraper.API.Representations;
using Moq;
using NUnit.Framework;

namespace InfoTrack.SearchScraper.Tests.Services.GoogleSearchServiceTests
{
    [TestFixture]
    public class GoogleSearchServiceTest : GoogleSearchServiceTestBase
    {
        [Test]
        [AutoData]
        public void Search_CallsConverter(SearchRequestRepresentation fakesearchRequest)
        {
            Service.Search(fakesearchRequest);

            GoogleSearchConverterMock.Verify(c => c.Convert(fakesearchRequest), Times.Once);
        }


        [Test]
        [AutoData]
        public void Search_CallsSetCookie_HtmlRetriever(SearchRequestRepresentation fakerepresentation, SearchRequest fakeentity)
        {
            GoogleSearchConverterMock.Setup(c => c.Convert(fakerepresentation)).Returns(fakeentity);
            HtmlRetrieverServiceMock.Setup(c => c.GetHtmlDocumentAsync(It.IsAny<string>(), It.IsAny<Url>(), It.IsAny<string>())).ReturnsAsync(It.IsAny<IDocument>());

            Service.Search(fakerepresentation);

            HtmlParserServiceMock.Verify(c => c.Parse(It.IsAny<IDocument>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
