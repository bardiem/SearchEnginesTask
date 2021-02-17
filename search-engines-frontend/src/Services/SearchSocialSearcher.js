import ConvertHelper from './ConvertHelper'

class SearchSocialSearcher{

    engineName = "Social Searcher"
    searcherUrl = "https://api.social-searcher.com/v2/search?q="
    secondPart = "&limit=20&lang=uk,en&network=web,twitter,facebook&key=4e8ac401f4f226a8f78f8b9bede3f37d";
    convertHelper = new ConvertHelper()

    getSearchResults = async (query) =>{
        alert("Пошук триватиме кілька секунд")
        const searchUrl = this.searcherUrl + query + this.secondPart;
        const res = await fetch(searchUrl);
        const data = await res.json();
        let result = this.toBaseModel(data)
        return result
    }

    toBaseModel = (dataModel) =>{
        let result = []
        dataModel.posts.map(post =>{
            switch(post.network){
                case "twitter":
                    result.push(this.convertHelper.toBasicModel(post.user.name, post.url, post.network, post.text))
                    break
                case "facebook":
                    result.push(this.convertHelper.toBasicModel(post.user.name, post.url, post.network, post.text))
                    break
                case "web":
                    result.push(this.convertHelper.toBasicModel(post.user.name, post.url, post.network, post.text))
                    break;
            }
        })
        return result;
    }
    
}

export default SearchSocialSearcher