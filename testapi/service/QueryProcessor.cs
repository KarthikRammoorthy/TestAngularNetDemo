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
            response.PalindromeCount = palindromes.Count;

            /*          var messageWithoutSpaces = Regex.Replace(queryItem.Message, @"\s+", "");
                     var messageRemoveSpecialCharacters = Regex.Replace(messageWithoutSpaces, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                     var quesrywithOutSpaces = Regex.Replace(queryItem.Query, @"\s+", "");
                     var queryRemoveSpecialCharacters = Regex.Replace(messageWithoutSpaces, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                     response.Count = Regex.Matches(messageRemoveSpecialCharacters, queryRemoveSpecialCharacters).Count; */

            var messageList = queryItem.Message.Split(',').Select(message => Regex.Replace(message, @"\s+", "")).ToList<string>();
            var quesrywithOutSpaces = Regex.Replace(queryItem.Query, @"\s+", "");
            response.Count = messageList.Count(message => message.ToLower().Contains(quesrywithOutSpaces.ToLower()));


            char[] queryArrays = quesrywithOutSpaces.ToCharArray();
            Array.Reverse(queryArrays);
            var queryInReverse = new string(queryArrays);
            response.ReverseCount = messageList.Count(message => message.ToLower().Contains(queryInReverse.ToLower()));

            //response.ReverseCount = Regex.Matches(messageRemoveSpecialCharacters, queryInReverse).Count;

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