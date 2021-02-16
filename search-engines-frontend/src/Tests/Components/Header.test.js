import React from 'react'
import ReactDOM from 'react-d'
import Header from '../Header'

it("renders without crashing", ()=>{
    const header = document.createElement("header")
    ReactDOM.render(<Header></Header>, header)
})