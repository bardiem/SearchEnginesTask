import React, {useState} from 'react'
import Switch from 'react-switch'


const SearchBar = ({onSearch, searchEngines}) => {
    const [searchQuery, setSearchQuery] = useState('')
    const [isInternetSearch, setIsInternetSearch] = useState(true)
    const [searchEngine, setSearchEngine] = useState(searchEngines[0])

    return (
        <div className="row">
            <div className="col-5 pt-3 pr-4 pb-3">
                <input 
                type="text" 
                className="form-control" 
                onChange={(e)=>setSearchQuery(e.target.value)} 
                value={searchQuery}
                />
            </div>
            <div className="col-5 row pt-3 pb-3 pr-2 pl-2">
                <div className="col-5">
                    <select className="form-select" aria-label="Default select example" value={searchEngine} onChange={(e)=>{setSearchEngine(e.target.value)}}>
                        {
                            searchEngines.map(engine => (
                            <option key={engine.engineName} value={engine.engineName}>{engine.engineName}</option>
                            ))
                        }
                        
                    </select>
                </div>
                <div className="col-7 row">
                    <div className="col-8 pt-2 pl-8">Пошук в інтернеті:</div>
                    <div className="col-4 pr-8 pt-1"><Switch onChange={setIsInternetSearch} checked={isInternetSearch}/></div>
                </div>
            </div>
            <div className="col-1 p-3">
                <button type="button" className="btn btn-outline-dark" onClick={()=>onSearch(searchQuery, searchEngine, isInternetSearch)}>Пошук</button>
            </div>
        </div>
    )
}

export default SearchBar
