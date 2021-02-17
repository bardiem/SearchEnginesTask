import React, {useState} from 'react'


const SearchBar = ({onSearch, searchEngines}) => {
    const [searchQuery, setSearchQuery] = useState('')
    const [searchEngine, setSearchEngine] = useState(searchEngines[0].engineName)

    return (
        <div className="row">
            <div className="col-9 pt-3 pr-4 pb-3">
                <input 
                type="text" 
                className="form-control" 
                onChange={(e)=>setSearchQuery(e.target.value)} 
                value={searchQuery}
                />
            </div>
            <div className="col-2 row pt-3 pb-3 pr-2 pl-2">
                
                    <select className="form-select" aria-label="Default select example" value={searchEngine} onChange={(e)=>{setSearchEngine(e.target.value)}}>
                        {
                            searchEngines.map(engine => (
                            <option key={engine.engineName} value={engine.engineName}>{engine.engineName}</option>
                            ))
                        }
                        
                    </select>

            </div>
            <div className="col-1 p-3">
                <button type="button" className="btn btn-outline-dark" onClick={()=>onSearch(searchQuery, searchEngine)}>Пошук</button>
            </div>
        </div>
    )
}

export default SearchBar
