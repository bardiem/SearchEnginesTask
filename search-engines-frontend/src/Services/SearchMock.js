import { getDefaultNormalizer } from "@testing-library/react";

class SearchMock{
    engineName = "Mock"
    

    getSearchResults = (query) =>{
        let data = [{
            title: "youtube.com",
            link: "https://youtube.com",
            displayLink: "youtube.com",
            snippet: "hello this is snippet"
        },
        {
            title: "google.com",
            link: "https://youtube.comyoutube.com",
            displayLink: "youtube.com",
            snippet: "hello this is snippet"
        },
        {
            title: "youtube.com1",
            link: "https://youtube.comyoutube.com",
            displayLink: "youtube.com",
            snippet: "hello this is snippet"
        },
        {
            title: "youtube.com2",
            link: "https://youtube.comyoutube.com",
            displayLink: "youtube.com",
            snippet: "hello this is snippet"
        }]
        return data
    }

}

export default SearchMock