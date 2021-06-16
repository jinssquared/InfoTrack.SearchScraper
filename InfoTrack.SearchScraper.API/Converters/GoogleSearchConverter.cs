using InfoTrack.SearchScraper.API.Entities;
using InfoTrack.SearchScraper.API.Interfaces;
using InfoTrack.SearchScraper.API.Representations;

namespace InfoTrack.SearchScraper.API.Converters
{
    public class GoogleSearchConverter : IGoogleSearchConverter
    {
        public string Convert(string searchTerm)
        {
            return searchTerm.Replace(' ', '+');
        }

    }
}
