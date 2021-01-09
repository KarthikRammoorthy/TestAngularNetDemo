using testapi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections;
using System;

namespace testapi.Service
{
    public class QueryProcessor : IQueryProcessor
    {
        public Response QueryProcessing(QueryRequest queryItem)
        {
            var message = queryItem.Message;
            var palindromes = GetPalindromes(message);
            var response = new Response();
            response.Palindromes = palindromes.ToArray();

            var messageWithoutSpaces = Regex.Replace(queryItem.Message, @"\s+", "");
            var quesrywithOutSpaces = Regex.Replace(queryItem.Query, @"\s+", "");
            response.Count = Regex.Matches(messageWithoutSpaces, quesrywithOutSpaces).Count;

            char[] queryArrays = quesrywithOutSpaces.ToCharArray();
            Array.Reverse(queryArrays);
            var queryInReverse = new string(queryArrays);
            response.ReverseCount = Regex.Matches(messageWithoutSpaces, queryInReverse).Count;

            return response;

        }

        private static List<string> GetPalindromes(string source)
        {
            try
            {
                List<string> subsets = new List<string>();
                for (int i = 0; i < source.Length - 1; i++)
                {
                    for (int j = i + 1; j <= source.Length; j++)
                    {
                        if (j - i > 1 && source[j - 1] == source[i])
                        {
                            string currentSubset = source.Substring(i, j - i);
                            if (IsPalindrome(currentSubset))
                            {
                                subsets.Add(currentSubset);
                            }
                        }
                    }
                }
                return subsets;
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        private static bool IsPalindrome(string input) => !input.Where((t, i) => t != input[input.Length - 1 - i]).Any();
    }
}