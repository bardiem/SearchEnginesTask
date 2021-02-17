using Xunit;
using Moq;
using Autofac.Extras.Moq;
using SearchEnginesTask.Repository;
using System.Collections.Generic;
using SearchEnginesTask.Models;
using SearchEnginesTask.Services;
using System.Linq;

namespace SearchEnginesTask.Tests
{
    public class StoreResultsServiceTest
    {

        [Fact]
        public void CreateSearchResults_WorksCorrectly()
        {
            var helper = new StoreResultsHelper();
            using (var mock = AutoMock.GetLoose())
            {
                
                mock.Mock<IGenericRepository<PhrasesOfResult>>()
                    .Setup(x => x.Create(GetOnePhraseOfResult());

                var cls = mock.Create<StoreResultsService>();

                cls.CreateSearchResults(GetSearchResults());

                int timesExpected = 0;
                foreach(var item in GetSearchResults())
                {
                    var res = helper.GetKeyPhrasesFromQuery(item.Title).Count();
                    timesExpected += res;
                }


                mock.Mock<IGenericRepository<PhrasesOfResult>>()
                    .Verify(x => x.Create(GetOnePhraseOfResult()), Times.Exactly(timesExpected));

            }
        }

        [Fact]
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
                    Title = "Facebook",
                    Link = "https://facebook.com/feed",
                    DisplayLink = "facebook.com",
                    Snippet = "Facebook main page"
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
                },
                new SearchResult
                {
                    Title = "Wikipedia - find everything",
                    Link = "https://wikipedia.com/",
                    DisplayLink = "wikipedia.com",
                    Snippet = "Find anything here"
                }
            };
            return searchResults;

        }

        private PhrasesOfResult GetOnePhraseOfResult()
        {
            var result = new PhrasesOfResult
            {
                Phrase = new KeyPhrase
                {
                    Phrase = "youtube"
                },
                Result = new SearchResult
                {
                    Title = "Youtube",
                    Link = "https://youtube.com/",
                    DisplayLink = "youtube.com",
                    Snippet = "Access all the youtube videos online"
                }
            };
            return result;
        }

        private List<SearchResult> GetResultOfYoutubeLink()
        {
            return new List<SearchResult>
            {
                new SearchResult{
                    Title = "Youtube",
                    Link = "https://youtube.com/",
                    DisplayLink = "youtube.com",
                    Snippet = "Access all the youtube videos online" }
            };
        }
    }
}
