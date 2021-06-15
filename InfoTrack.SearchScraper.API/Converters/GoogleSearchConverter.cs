using InfoTrack.SearchScraper.API.Entities;
using InfoTrack.SearchScraper.API.Interfaces;
using InfoTrack.SearchScraper.API.Representations;

namespace InfoTrack.SearchScraper.API.Converters
{
    public class GoogleSearchConverter : IGoogleSearchConverter
    {
        public SearchRequest Convert(SearchRequestRepresentation representation)
        {
            return new SearchRequest
            {
                SearchTerm = representation.SearchTerm.Replace(' ', '+'),
                UrlToMatch = representation.UrlToMatch
            };
        }

    }
}
