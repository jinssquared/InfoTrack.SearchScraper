using AngleSharp;
using InfoTrack.SearchScraper.API.Interfaces;
using InfoTrack.SearchScraper.API.Representations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfoTrack.SearchScraper.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {

        private readonly IGoogleSearchService _googleSearchService;

        public SearchController(IGoogleSearchService googleSearchService)
        {
            _googleSearchService = googleSearchService;
        }


        [HttpGet]
        [Route("SearchGoogle/{searchTerm}/Match/{urlToMatch}", Name = "SearchGoogle")]
        public async Task<IActionResult> SearchGoogle(string searchTerm, string urlToMatch)
        {
            return Ok(await _googleSearchService.Search(searchTerm, urlToMatch));
        }
    }
}
