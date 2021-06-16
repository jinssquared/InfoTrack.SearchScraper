using InfoTrack.SearchScraper.API.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfoTrack.SearchScraper.API.Services
{
    public class BasicHtmlRetrieverService : IHtmlRetrieverService
    {
        public async Task<string> GetHtmlDocumentAsync(string baseUrl, Uri baseAddress, Cookie cookie)
        {
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                if(cookie != null)
                    cookieContainer.Add(baseAddress, cookie);

                var result = await client.GetAsync(baseUrl);
                return await result.Content.ReadAsStringAsync();
            }
        }
    }
}
