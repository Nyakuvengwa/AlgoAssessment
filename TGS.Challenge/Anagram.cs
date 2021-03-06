using System;
using System.Linq;

namespace TGS.Challenge
{
  /*
        Devise a function that checks if 1 word is an anagram of another, if the words are anagrams of
        one another return true, else return false

        "Anagram": An anagram is a type of word play, the result of rearranging the letters of a word or
        phrase to produce a new word or phrase, using all the original letters exactly once; for example
        orchestra can be rearranged into carthorse.

        areAnagrams("horse", "shore") should return true
        areAnagrams("horse", "short") should return false

        NOTE: Punctuation, including spaces should be ignored, e.g.

        horse!! shore = true
        horse  !! shore = true
          horse? heroes = true

        There are accompanying unit tests for this exercise, ensure all tests pass & make
        sure the unit tests are correct too.
     */
    public class Anagram
    {
      public bool AreAnagrams(string word1, string word2)
      {
            word1 = word1.ToLower();
            word2 = word2.ToLower();

            if (string.IsNullOrWhiteSpace(word1))
            {
                throw new  ArgumentException($"{nameof(word1)} is required");
            }

            if (string.IsNullOrWhiteSpace(word2))
            {
                throw new ArgumentException($"{nameof(word2)} is required");
            }            
                
            foreach (var item in word2.ToCharArray())
            {
               word1 =  word1.Replace(item, ' ');
            }

            var words = word1
                .Where(c => !char.IsPunctuation(c))
                .Where(c => !char.IsWhiteSpace(c))
                .Where(c => !char.IsPunctuation(c))
                .ToArray();

            return words.Length == 0;
      }
    }
}
