using AngleSharp.Dom;
using System.Collections.Generic;

namespace InfoTrack.SearchScraper.API.Interfaces
{
    public interface IHtmlParserService
    {
        ICollection<int> Parse(IDocument document, string selectorNode, string urlToMatch); 
    }
}
