using InfoTrack.SearchScraper.API.Interfaces;
using InfoTrack.SearchScraper.API.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace InfoTrack.SearchScraper.Tests.Services.GoogleSearchServiceTests
{
    [TestFixture]
    public class GoogleSearchServiceTestBase
    {
        protected Mock<IHtmlRetrieverService> HtmlRetrieverServiceMock;
        protected Mock<IGoogleSearchConverter> GoogleSearchConverterMock;
        protected Mock<IConfiguration> ConfigurationMock;
        protected Mock<IHtmlParserService> HtmlParserServiceMock;

        protected GoogleSearchService Service;

        public GoogleSearchServiceTestBase()
        {
            HtmlRetrieverServiceMock = new Mock<IHtmlRetrieverService>();
            GoogleSearchConverterMock = new Mock<IGoogleSearchConverter>();
            ConfigurationMock = new Mock<IConfiguration>();
            HtmlParserServiceMock = new Mock<IHtmlParserService>();

            ConfigurationMock.Setup(c => c[It.IsAny<string>()]).Returns("dummy");


            Service = new GoogleSearchService(HtmlRetrieverServiceMock.Object, 
                    ConfigurationMock.Object, 
                    GoogleSearchConverterMock.Object,
                    HtmlParserServiceMock.Object);


        }
    }
}
