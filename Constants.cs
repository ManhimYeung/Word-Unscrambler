﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Constants
    {
        public const string OptionsOnHowToEnterScrambledWOrds = "Enter scrambled word(s) manually or as a file: F- file/M - manual";
        public const string OptionsOnContinuingTheProgram = "Would you like to continue? Y/N";

        public const string EnterScrambledWordsViaFile = "Enter full path including the file name: ";
        public const string EnterScrambledWordsManually = "Enter word(s) manually (separated by commas if multiple): ";
        public const string EnterScrambledWordsOptionNotRecognised = "The option was not recognised. ";
        public const string ErrorScrambledWordsCannotBeLoaded = "Scrambled words were not loaded because there was an error: ";
        public const string ErrorProgramWillBeTerminated = "The program will be terminated: ";
        public const string MatchFound = "Match found for {0}: {1}";
        public const string MatchNotFound = "No matches have been found! ";

        public const string Yes = "Y";
        public const string No = "N";
        public const string File = "F";
        public const string Manual = "M";

        public const string wordListFileName = "wordlist.txt";
    }
}
