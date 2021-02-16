import ConvertHelper from './ConvertHelper';

class SearchNewsApi{
    convertHelper = new ConvertHelper()
    engineName = "News Search"
    webSearchUrl = "http://newsapi.org/v2/everything?q="
    secondPart = "&from=2021-02-16&sortBy=popularity&apiKey=460768b0e2c04025801170371b8a806b"

    getSearchResults = async (query) =>{

        const searchUrl = this.webSearchUrl + query + this.secondPart
        const req = new Request(searchUrl)
        const res = await fetch(req)

        const data = await res.json();
        const result = this.newsApiToBaseModel(data)
        return result
    }

    newsApiToBaseModel = (data) => {
        let result = []
        data.articles.map(article=>{
            result.push(this.convertHelper.toBasicModel(article.title, article.url, article.author, article.description))
        })
        return result
    }

}

export default SearchNewsApi