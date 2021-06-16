using AngleSharp.Dom;
using System.Collections.Generic;

namespace InfoTrack.SearchScraper.API.Interfaces
{
    public interface IHtmlParserService
    {
        ICollection<int> Parse(string document, string selectorNode, string urlToMatch); 
    }
}
