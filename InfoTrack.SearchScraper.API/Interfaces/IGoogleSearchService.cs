using InfoTrack.SearchScraper.API.Representations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoTrack.SearchScraper.API.Interfaces
{
    public interface IGoogleSearchService 
    {
        Task<ICollection<int>> Search(string searchTerm, string urlToMatch);
    }
}
