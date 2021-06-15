using AngleSharp;
using AngleSharp.Dom;
using InfoTrack.SearchScraper.API.Interfaces;
using System.Threading.Tasks;

namespace InfoTrack.SearchScraper.API.Services
{
    public class HtmlRetrieverService : IHtmlRetrieverService
    {
        private readonly IConfiguration _angleSharpConfiguration;

        private readonly IBrowsingContext _browsingContext;

        public HtmlRetrieverService()
        {
            _angleSharpConfiguration = Configuration.Default.WithDefaultLoader();

            _browsingContext = BrowsingContext.New(_angleSharpConfiguration);
        }

        public async Task<IDocument> GetHtmlDocumentAsync(string url, Url baseAddress, string cookie)
        {
            if(baseAddress != null && !string.IsNullOrEmpty(cookie))
                _browsingContext.SetCookie(baseAddress, cookie);
            
            return await _browsingContext.OpenAsync(url);
        }
    }
}
