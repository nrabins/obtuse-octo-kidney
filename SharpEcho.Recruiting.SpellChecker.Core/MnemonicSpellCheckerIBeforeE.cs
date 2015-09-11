using SharpEcho.Recruiting.SpellChecker.Contracts;

namespace SharpEcho.Recruiting.SpellChecker.Core
{
    /// <summary>
    /// This spell checker implements the following rule:
    /// "I before E, except after C" is a mnemonic rule of thumb for English spelling.
    /// If one is unsure whether a word is spelled with the sequence ei or ie, the rhyme
    /// suggests that the correct order is ie unless the preceding letter is c, in which case it is ei. 
    /// 
    /// Examples: believe, fierce, collie, die, friend, deceive, ceiling, receipt would be evaulated as spelled correctly
    /// heir, protein, science, seeing, their, and veil would be evaluated as spelled incorrectly.
    /// </summary>
    public class MnemonicSpellCheckerIBeforeE : ISpellChecker
    {
        /// <summary>
        /// Returns false if the word contains a letter sequence of "ie" when it is immediately preceded by c
        /// </summary>
        /// <param name="word">The word to be checked</param>
        /// <returns>true when the word is spelled correctly, false otherwise</returns>
        public bool Check(string word)
        {
            // testing the lowercase version of the word simpifies things later on
            string lower = word.ToLower();

            // things we don't like:

            // "ie" with a preceding 'c'
            if (lower.Contains("cie"))
            {
                return false;
            }
            
            // "ei" without a preceding 'c'

            // bounds explanation: we're testing the string everywhere we find an 'e'.
            // we know an 'e' at the start or end of the word is valid, so we don't need to test those edge cases.
            for (int i = 1; i < lower.Length-1; i++)
            {
                if (lower[i] == 'e' && lower[i+1] == 'i' && lower[i - 1] != 'c')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
