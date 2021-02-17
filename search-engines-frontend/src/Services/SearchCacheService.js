
class SearchCacheService{

    postSearchResults = (results) => {
        const res = fetch(process.env.REACT_APP_SERVER_DEFAULT_URL+"api/searchResults",
        {
            method: 'POST',
            headers:{
                'Content-type': 'application/json;charset=UTF-8'
            },
            body: JSON.stringify(results)
        })
    }

    getSearchResultsFromServer = async(query) =>{
        
    }
}

export default SearchCacheService