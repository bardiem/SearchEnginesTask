import React from 'react'

const SearchResult = ({searchResult}) => {
    return (
        <div className="mb-3"> 
            <a href={searchResult.link}>
                <h5>{searchResult.title}</h5>
            </a>
            <h6 className="mb-2 text-muted">{searchResult.displayLink}</h6>
            <p className="card-text">{searchResult.snippet}</p>
            
        </div>
    )
}

export default SearchResult
