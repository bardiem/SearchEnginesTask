using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            
        }


        [HttpPost]
        public ActionResult<SearchResult> PostSearchResult([FromBody] IEnumerable<SearchResult> searchResult)
        {
            try
            {
                _searchRepository.CreateMany(searchResult);
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }

    }
}
