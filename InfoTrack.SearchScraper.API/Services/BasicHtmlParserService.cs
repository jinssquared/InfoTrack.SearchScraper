using InfoTrack.SearchScraper.API.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace InfoTrack.SearchScraper.API.Services
{
    public class BasicHtmlParserService : IHtmlParserService
    {
        public ICollection<int> Parse(string document, string selectorNode, string urlToMatch)
        {
            List<char> selectorNodeArray = selectorNode.ToCharArray().ToList();
            List<char> urlToMatchArray = urlToMatch.ToCharArray().ToList();

            List<char> charStepperSelector = new List<char>();
            List<char> charStepperUrl = new List<char>();

            int selectorHits = 0;
            bool onHit = false;
            List<int> urlHits = new List<int>();

            foreach (var c in document)
            {
                if (onHit && charStepperUrl.Count < urlToMatchArray.Count)
                    charStepperUrl.Add(c);

                if (charStepperUrl.Count == urlToMatchArray.Count)
                {
                    if (charStepperUrl.SequenceEqual(urlToMatchArray))
                        urlHits.Add(selectorHits);

                    onHit = false;
                    charStepperUrl = new List<char>();
                }

                if (charStepperSelector.Count == selectorNodeArray.Count)
                    charStepperSelector.RemoveAt(0);

                charStepperSelector.Add(c);

                if (charStepperSelector.SequenceEqual(selectorNodeArray))
                {
                    selectorHits++;
                    onHit = true;
                }
            }

            return urlHits;
        }
    }
}
