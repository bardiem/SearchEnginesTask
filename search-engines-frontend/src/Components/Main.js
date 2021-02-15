import React from 'react'
import SearchResult from './SearchResult'

const Main = ({searchResults}) => {
    console.log(searchResults)
    if(searchResults.length>0){
        return (
        <main className="col-9">
            <div className="d-flex flex-column bd-highlight mb-3">
                {searchResults.map((result, index) => (<SearchResult key={index} searchResult={result}/>))}
            </div>
        </main>)
    }else{
        return (
        <main className="col-9">
            <div className="d-flex flex-column bd-highlight mb-3">
                Введіть пошуковий запит або URL та натисність Пошук
            </div>
        </main>)
    }
}


export default Main