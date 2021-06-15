using AngleSharp;
using InfoTrack.SearchScraper.API.Interfaces;
using InfoTrack.SearchScraper.API.Representations;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoTrack.SearchScraper.API.Services
{
    public class GoogleSearchService : IGoogleSearchService
    {
        private readonly IHtmlRetrieverService _htmlRetrieverService;

        private readonly IGoogleSearchConverter _googleSearchConverter;

        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;

        private readonly IHtmlParserService _htmlParserService;

        public GoogleSearchService(IHtmlRetrieverService htmlRetrieverService,
            Microsoft.Extensions.Configuration.IConfiguration configuration,
            IGoogleSearchConverter googleSearchConverter, 
            IHtmlParserService htmlParserService)
        {
            _htmlRetrieverService = htmlRetrieverService;
            _configuration = configuration;
            _googleSearchConverter = googleSearchConverter;
            _htmlParserService = htmlParserService;
        }

        public async Task<ICollection<int>> Search(SearchRequestRepresentation searchRequestRepresentation)
        {
            var searchRequest = _googleSearchConverter.Convert(searchRequestRepresentation);

            var searchUrl = string.Format($"{_configuration["GoogleBaseUrl"]}/{_configuration["GoogleQueryString"]}", searchRequest.SearchTerm);

            var document = await _htmlRetrieverService.GetHtmlDocumentAsync(searchUrl, new Url(_configuration["GoogleBaseUrl"]), _configuration["GoogleCookieConsentCookie"]);
          
            return _htmlParserService.Parse(document, _configuration["GoogleDocParserValue"], searchRequest.UrlToMatch);
        }
    }
}
