
class SearchLocal{

    engineName = "Local"
    googleUrl = process.env.REACT_APP_SERVER_DEFAULT_URL + "api/searchResults" +"/" ;

    getSearchResults = async (query) =>{
        const searchUrl = this.googleUrl + query;
        const res = await fetch(searchUrl);
        const data = await res.json();
        return data
    }
    

}

export default SearchLocal