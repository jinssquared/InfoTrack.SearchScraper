using InfoTrack.SearchScraper.API.Entities;
using InfoTrack.SearchScraper.API.Representations;

namespace InfoTrack.SearchScraper.API.Interfaces
{
    public interface IGoogleSearchConverter
    {
        SearchRequest Convert(SearchRequestRepresentation representation);
    }
}
