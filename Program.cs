using System;
using System.Collections.Generic;
using System.Linq;
using WordUnscrambler.Workers;
using WordUnscrambler.Data;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();
        

        static void Main(string[] args)
        {
            try
            {
                bool continueWordUnscramble = true;
                do
                {
                    Console.Write(Constants.OptionsOnHowToEnterScrambledWOrds);
                    var option = Console.ReadLine() ?? string.Empty;

                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.Write(Constants.EnterScrambledWordsViaFile);
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case Constants.Manual:
                            Console.Write(Constants.EnterScrambledWordsManually);
                            ExecuteScrambledWordsManualEntryScenario();
                            break;
                        default:
                            Console.Write(Constants.EnterScrambledWordsOptionNotRecognised);
                            break;
                    }

                    var continueWordUnscrambleDecision = string.Empty;
                    do
                    {
                        Console.WriteLine(Constants.OptionsOnContinuingTheProgram);
                        continueWordUnscrambleDecision = (Console.ReadLine() ?? string.Empty);
                    } while (!continueWordUnscrambleDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                             !continueWordUnscrambleDecision.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

                    continueWordUnscramble = continueWordUnscrambleDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);
                } while (continueWordUnscramble);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorProgramWillBeTerminated + ex.Message);
            }
           
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayMatchedUnscrambledWords(scrambledWords);
        }
        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            try
            {
                var filename = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = _fileReader.Read(filename);
                DisplayMatchedUnscrambledWords(scrambledWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded + ex.Message);
            }
        }
        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(Constants.wordListFileName);

            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any())
            {
                foreach(var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else
            {
                Console.WriteLine(Constants.MatchNotFound);
            }
        }


    }
}
