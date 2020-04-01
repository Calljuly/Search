using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestChamber")]

namespace ClassLibrary
{
    public class Word
    {
        internal string word;
        internal string file;

        public Word(string theWord, string theFile)
        {
            word = theWord;
            file = theFile;
        }
    }
}
