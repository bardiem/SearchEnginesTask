class ConvertHelper{
    toBasicModel = (title, link, displayLink, snippet) =>{
        let resultItem = new Object()
        resultItem.title = title
        resultItem.link = link
        resultItem.displayLink = displayLink
        resultItem.snippet = snippet
        return resultItem
    }
}

export default ConvertHelper