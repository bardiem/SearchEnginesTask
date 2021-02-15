import React from 'react'
import SearchBar from './SearchBar'

const Header = ({onSearch}) => {
    return (
        <header className="col-12">
            <SearchBar onSearch={onSearch}/>
        </header>
    )
}

export default Header
