import './App.css';
import Header from './Components/Header';
import Main from './Components/Main';
import {useState} from 'react';
import SearchProvider from './Services/SearchProvider'
import SearchCacheService from './Services/SearchCacheService'


function App() {
  let [searchResults, setSearchResults] = useState([]);
  const searchProvider = new SearchProvider()
  const searchCacheService = new SearchCacheService()


  const onSearch = async (searchQuery, searchEngine) => {
    if(searchQuery===undefined || searchQuery===null || searchQuery.length==0)
      return;
      
    let data = await searchProvider.getQueryResult(searchQuery, searchEngine)
    data = data.slice(0, 10)
    
    setSearchResults(data)
    searchCacheService.postSearchResults(data)
  }

  return (
    <div className="container">
      <div className="row row-cols-2">
        <Header onSearch={onSearch} searchEngines={searchProvider.searchEngines}/>
        <Main searchResults={searchResults}/>
      </div>
    </div>
  );
}

export default App;
