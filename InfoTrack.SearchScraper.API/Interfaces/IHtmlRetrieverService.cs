using AngleSharp;
using AngleSharp.Dom;
using System.Threading.Tasks;

namespace InfoTrack.SearchScraper.API.Interfaces
{
    public interface IHtmlRetrieverService
    {
        Task<IDocument> GetHtmlDocumentAsync(string baseUrl, Url baseAddress, string cookie);
    }
}
