using Xunit;
using Moq;
using Autofac.Extras.Moq;
using SearchEnginesTask.Repository;
using System.Collections.Generic;
using SearchEnginesTask.Models;

namespace SearchEnginesTask.Tests.Utilities
{
    public class RepositoriesTest
    {
        [Fact]
        public void GetSearchResults_WorksCorrectly()
        {
            using(var mock = AutoMock.GetLoose())
            {
                mock.Mock<ISearchResultRepository>()
                    .Setup(x => x.Get(new[] { "youtube", "sign up" }))
                    .Returns(GetSearchResults());
                
            }
        }


        private List<SearchResult> GetSearchResults()
        {
            var searchResults = new List<SearchResult> {
                new SearchResult
                {
                    Title = "Youtube",
                    Link = "https://youtube.com/",
                    DisplayLink = "youtube.com",
                    Snippet = "Access all the youtube videos online"
                },
                new SearchResult
                {
                    Title = "Youtube - Sign up",
                    Link = "https://youtube.com/signup",
                    DisplayLink = "youtube.com",
                    Snippet = "Sign up for free"
                },
                new SearchResult
                {
                    Title = "facebook - Sign up",
                    Link = "https://facebook.com/signup",
                    DisplayLink = "facebook.com",
                    Snippet = "Sign up in facebook for free and connect with everyone"
                }
            };
            return searchResults;

        }
    }
}
