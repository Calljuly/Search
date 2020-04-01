using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestChamber")]

namespace ClassLibrary
{
    public class Word
    {
        public string Value { get; private set; }
        public string File { get; private set; }

        public Word(string theWord, string theFile)
        {
            Value = theWord;
            File = theFile;
        }
    }
}
