import SearchGoogle from './SearchGoogle'
import SearchLocal from './SearchLocal'

class SearchProvider{
    searchEngines

    constructor(){
        let googleEngine = new SearchGoogle()
        let searchLocal = new SearchLocal()
        this.searchEngines = [googleEngine, searchLocal]
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