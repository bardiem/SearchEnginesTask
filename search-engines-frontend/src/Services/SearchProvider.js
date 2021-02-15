import SearchGoogle from './SearchGoogle'
import SearchMock from './SearchMock'

class SearchProvider{
    searchEngines

    constructor(){
        let googleEngine = new SearchGoogle()
        let searchMock = new SearchMock()
        this.searchEngines = [googleEngine, searchMock]
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