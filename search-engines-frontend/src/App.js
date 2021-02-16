import './App.css';
import Header from './Components/Header';
import Sidebar from './Components/Sidebar';
import Main from './Components/Main';
import {useState} from 'react';
import SearchProvider from './Services/SearchProvider'
import SearchCacheService from './Services/SearchCacheService'
import SearchResult from './Components/SearchResult';

function App() {
  let [searchResults, setSearchResults] = useState([{
        title: "youtube.com1",
        link: "https://youtube.comyoutube.com",
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


  const onSearch = async (searchQuery) => {
    //const data = await searchProvider.getQueryResult(searchQuery, "google")
    const data = searchProvider.getQueryResult(searchQuery, "mock")
    
    setSearchResults(data)
    searchCacheService.postSearchResults(data)
  }

  return (
    <div className="container">
      <div className="row row-cols-2">
        <Header onSearch={onSearch}/>
        <Main searchResults={searchResults}/>
        <Sidebar />
      </div>
    </div>
  );
}

export default App;
