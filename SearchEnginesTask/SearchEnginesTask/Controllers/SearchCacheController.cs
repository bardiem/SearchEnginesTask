using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchEnginesTask.Models;
using SearchEnginesTask.Services;


namespace SearchEnginesTask.Controllers
{
    [Route("api/searchResults")]
    [ApiController]
    public class SearchCacheController : ControllerBase
    {
        private readonly IStoreResultsService _storeResultsService;
        private readonly IStoreResultsHelper _localSearchService;


        public SearchCacheController(IStoreResultsHelper localSearchService, 
            IStoreResultsService storeResultsService)
        {
            _localSearchService = localSearchService;
            _storeResultsService = storeResultsService;
        }


        [HttpGet("{query}")]
        public ActionResult<IEnumerable<SearchResult>> GetSearchResults(string query) 
        {
            var keyPhrases = _localSearchService.GetKeyPhrasesFromQuery(query);
            var foundResults = _storeResultsService.GetSearchResults(keyPhrases);
            return Ok(foundResults);
        }


        [HttpPost]
        public ActionResult<SearchResult> PostSearchResult([FromBody] IEnumerable<SearchResult> searchResults)
        {
            try
            {
                _storeResultsService.CreateSearchResults(searchResults);
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }

    }
}
