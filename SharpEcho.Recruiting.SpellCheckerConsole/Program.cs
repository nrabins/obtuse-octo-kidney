using System;

using SharpEcho.Recruiting.SpellChecker.Contracts;
using SharpEcho.Recruiting.SpellChecker.Core;
using System.Collections.Generic;
using System.Text;

namespace SharpEcho.Recruiting.SpellCheckerConsole
{
    /// <summary>
    /// Thank you for your interest in a position at SharpEcho.  The following are the "requirements" for this project:
    /// 
    /// 1. Implent Main() below so that a user can input a sentance.  Each word in that
    ///    sentance will be evaluated with the SpellChecker, which returns true for a word
    ///    that is spelled correctly and false for a word that is spelled incorrectly.  Display
    ///    out each *distnict* word that is misspelled.  That is, if a user uses the same misspelled
    ///    word more than once, simply output that word one time.
    ///    
    ///    Example:
    ///    Please enter a sentance: Salley sells seashellss by the seashore.  The shells Salley sells are surely by the sea.
    ///    Misspelled words: Salley seashellss
    ///    
    /// 2. The concrete implementation of SpellChecker depends on two other implementations of ISpellChecker, DictionaryDotComSpellChecker
    ///    and MnemonicSpellCheckerIBeforeE.  You will need to implement those classes.  See those classes for details.
    ///    
    /// 3. There are covering unit tests in the SharpEcho.Recruiting.SpellChecker.Tests library that should be implemented as well.
    /// </summary>
    class Program
    {
        /// <summary>
        /// This application is intended to allow a user enter some text (a sentence)
        /// and it will display a distinct list of incorrectly spelled words
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            // use this spellChecker to evaluate the words
            var spellChecker = new SpellChecker.Core.SpellChecker
                (
                    new ISpellChecker[]
                    {
                        new MnemonicSpellCheckerIBeforeE(),
                        new DictionaryDotComSpellChecker(),
                    }
                );

            Console.Write("Please enter a sentance: ");
            var sentance = Console.ReadLine();

            // use this ArrayList to accumulate unique words
            var misspelledWords = new List<string>();

            // first break the sentance up into words
            string[] words = sentance.Split(' ');


            // then iterate through the list of words using the spell checker
            // capturing distinct words that are misspelled
            foreach (string word in words)
            {
                // strip word down to letters only
                var sb = new StringBuilder();
                foreach (char c in word)
                {
                    if (char.IsLetter(c))
                    {
                        sb.Append(c);
                    }
                }
                var strippedWord = sb.ToString();
                Console.WriteLine("Checking \"{0}\"", strippedWord);
                if (!spellChecker.Check(strippedWord) && !misspelledWords.Contains(strippedWord))
                {
                    misspelledWords.Add(strippedWord);
                }
            }

            if (misspelledWords.Count == 0)
            {
                Console.Write("[no misspellings]");
            }
            else
            {
                Console.Write("misspellings: ");
                foreach (string misspelledWord in misspelledWords)
                {
                    Console.Write("{0} ", misspelledWord);
                }
            }


            Console.ReadLine(); // for pausing to view output

        }
    }
}
