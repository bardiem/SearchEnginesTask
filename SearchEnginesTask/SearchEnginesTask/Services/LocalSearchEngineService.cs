using SearchEnginesTask.Models;
using System.Collections.Generic;
using System.Linq;


namespace SearchEnginesTask.Services
{
    public class LocalSearchEngineService : ILocalSearchEngineService
    {

        public IEnumerable<string> GetKeyPhrasesFromQuery(string query)
        {
            var keyWords = new List<string>();
            var queryWords = query.Split(" ");
            for (int i = 0; i < queryWords.Length; i++)
            {
                if (queryWords[i].Length > 2)
                {
                    keyWords.Add(queryWords[i]);
                }
                else
                {
                    keyWords.Add(GetPrevWord(i, queryWords));
                    keyWords.Add(GetNextWord(i, queryWords));
                }
            }
            var filteredKeyWords = keyWords.Where(item => item != "").ToList();
            return filteredKeyWords;
        }

        private static string GetPrevWord(int index, string[] array)
        {
            if (index == 0)
                return string.Empty;
            return array[index - 1] + " " + array[index];
        }

        private static string GetNextWord(int index, string[] array)
        {
            if (index == array.Count() - 1)
                return string.Empty;
            return array[index] + " " + array[index + 1];
        }
    }
}
