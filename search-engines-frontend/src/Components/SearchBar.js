import React, {useState} from 'react'


const SearchBar = ({onSearch}) => {
    const [searchQuery, setSearchQuery] = useState('')

    return (
        <div className="row">
            <div className="col-10 pt-3 pr-4 pb-3">
                <input 
                type="text" 
                className="form-control" 
                onChange={(e)=>setSearchQuery(e.target.value)} 
                value={searchQuery}
                />
            </div>
            <div className="col-2 p-3">
                <button type="button" className="btn btn-outline-dark" onClick={()=>onSearch(searchQuery)}>Пошук</button>
            </div>
        </div>
    )
}

export default SearchBar
