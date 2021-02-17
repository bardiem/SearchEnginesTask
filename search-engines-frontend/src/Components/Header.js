import React from 'react'
import SearchBar from './SearchBar'

const Header = ({onSearch, searchEngines}) => {
    return (
        <header className="col-12">
            <SearchBar onSearch={onSearch} searchEngines={searchEngines}/>
        </header>
    )
}

export default Header
