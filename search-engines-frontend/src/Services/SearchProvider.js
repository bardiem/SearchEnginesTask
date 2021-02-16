import SearchGoogle from './SearchGoogle'
import SearchLocal from './SearchLocal'
import SearchNewsApi from './SearchNewsApi'
import SearchSocialSearcher from './SearchSocialSearcher'


class SearchProvider{
    searchEngines

    constructor(){
        let googleEngine = new SearchGoogle()
        let searchLocal = new SearchLocal()
        let searchNewsApi = new SearchNewsApi()
        let searchSocial = new SearchSocialSearcher()
        this.searchEngines = [googleEngine, searchNewsApi, searchSocial, searchLocal]
    }


    getQueryResult(query, searchEngineName){
        let engine = this.getSearchEngine(searchEngineName)
        return engine.getSearchResults(query);
    }


    getSearchEngine(name){
        let result = null;
        let upperName = name.toUpperCase()
        this.searchEngines.map(engine=>{
            if(engine.engineName.toUpperCase() === upperName){
                result = engine;
            }
        })
        return result;
    }
}


export default SearchProvider