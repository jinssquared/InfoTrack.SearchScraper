using AngleSharp.Dom;
using InfoTrack.SearchScraper.API.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace InfoTrack.SearchScraper.API.Services
{
    public class HtmlParserService : IHtmlParserService
    {
        public ICollection<int> Parse(IDocument document, string selectorNode, string urlToMatch)
        {
            var resultUrlRows = document.QuerySelectorAll(selectorNode).ToList();

            List<int> results = new List<int>();

            for (var row = 0; row < resultUrlRows.Count(); row++)
            {
                if (resultUrlRows[row].InnerHtml.Contains(urlToMatch))
                    results.Add(row + 1);
            }

            return results.Any() ? results : new List<int> { 0 };
        }
    }
}
