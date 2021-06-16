using System;
using System.Net;
using System.Threading.Tasks;

namespace InfoTrack.SearchScraper.API.Interfaces
{
    public interface IHtmlRetrieverService
    {
        Task<string> GetHtmlDocumentAsync(string baseUrl, Uri baseAddress, Cookie cookie);
    }
}
