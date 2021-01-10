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
            var messageList = queryItem.Message.Split(',').Select(message => Regex.Replace(message, @"\s+", "")).ToList<string>();

            var palindromeList = GetPalindromes(messageList);
            var response = new Response();
            response.Palindromes = palindromeList.ToArray();
            response.PalindromeCount = palindromeList.Count;

            /*          var messageWithoutSpaces = Regex.Replace(queryItem.Message, @"\s+", "");
                     var messageRemoveSpecialCharacters = Regex.Replace(messageWithoutSpaces, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                     var quesrywithOutSpaces = Regex.Replace(queryItem.Query, @"\s+", "");
                     var queryRemoveSpecialCharacters = Regex.Replace(messageWithoutSpaces, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                     response.Count = Regex.Matches(messageRemoveSpecialCharacters, queryRemoveSpecialCharacters).Count; */

            var quesrywithOutSpaces = Regex.Replace(queryItem.Query, @"\s+", "");
            response.Count = messageList.Count(message => message.ToLower().Contains(quesrywithOutSpaces.ToLower()));


            char[] queryArrays = quesrywithOutSpaces.ToCharArray();
            Array.Reverse(queryArrays);
            var queryInReverse = new string(queryArrays);
            response.ReverseCount = messageList.Count(message => message.ToLower().Contains(queryInReverse.ToLower()));

            //response.ReverseCount = Regex.Matches(messageRemoveSpecialCharacters, queryInReverse).Count;

            return response;

        }

        public static List<string> GetPalindromes(List<string> messageList)
        {
            var palindromeList = new List<string>();

            messageList.ForEach(message =>
            {
                if (message.SequenceEqual(message.Reverse()))
                {
                    palindromeList.Add(message);

                }
            });
            return palindromeList;
        }
    }
}