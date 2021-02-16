import './App.css';
import Header from './Components/Header';
import Main from './Components/Main';
import {useState} from 'react';
import SearchProvider from './Services/SearchProvider'
import SearchCacheService from './Services/SearchCacheService'


function App() {
  let [searchResults, setSearchResults] = useState([{
        title: "youtube.com1",
        link: "https://youtube.comye.com",
        displayLink: "youtube.com",
        snippet: "hello this is snippet"
    },
    {
        title: "facebook.com",
        link: "https://youtube.comyoutube.com",
        displayLink: "youtube.com",
        snippet: "hello this is snippet"
    }]);
  const searchProvider = new SearchProvider()
  const searchCacheService = new SearchCacheService()


  const onSearch = async (searchQuery, searchEngine) => {
    //const data = await searchProvider.getQueryResult(searchQuery, "google")
    const data = searchProvider.getQueryResult(searchQuery, searchEngine)
    
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
