
class SearchGoogle{
    engineName = "google"
    googleUrl = "https://www.googleapis.com/customsearch/v1?key=AIzaSyAsJqQ09IwOqfbBIjspuuBRSXAQ4l2f_qM&cx=2b147fe9ab112bb9e&q=";

    getSearchResults = async (query) =>{
        const searchUrl = this.googleUrl + query;
        const res = await fetch(searchUrl);
        const data = await res.json();
        return data.items
    }

}

export default SearchGoogle
