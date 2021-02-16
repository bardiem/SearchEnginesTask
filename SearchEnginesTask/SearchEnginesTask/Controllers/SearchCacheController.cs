using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchEnginesTask.Models;
using SearchEnginesTask.Repository;
using SearchEnginesTask.Services; 


namespace SearchEnginesTask.Controllers
{
    [Route("api/searchResults")]
    [ApiController]
    public class SearchCacheController : ControllerBase
    {
        private readonly SearchDBContext _context;
        private readonly ISearchResultRepository _searchRepository;
        private readonly ILocalSearchEngineService _localSearchService;


        public SearchCacheController(SearchDBContext context,
            ISearchResultRepository searchResultRepository, 
            ILocalSearchEngineService localSearchService)
        {
            _context = context;
            _searchRepository = searchResultRepository;
            _localSearchService = localSearchService;
        }


        [HttpGet("{query}")]
        public async Task<ActionResult<IEnumerable<SearchResult>>> GetSearchResults(string query) 
        {
            var keyPhrases = _localSearchService.GetKeyPhracesFromQuery(query);
            var foundResults = _searchRepository.Get(keyPhrases);
            return Ok(foundResults);
        }


        [HttpPost]
        public ActionResult<SearchResult> PostSearchResult([FromBody] IEnumerable<SearchResult> searchResults)
        {
            try
            {
                //object p = searchResults.Select(e=> e.KeyPhrases = e.).;
                _searchRepository.CreateMany(searchResults);
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }

    }
}
