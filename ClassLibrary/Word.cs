using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestChamber")]

namespace SearchLibrary
{
    public interface ISearchable
    {
         string Value { get; set; }
         string File { get; set; }
    }
    public class Word : ISearchable
    {
        public string Value { get; set; }
        public string File { get; set; }

        public Word(string theWord, string theFile)
        {
            Value = theWord;
            File = theFile;
        }

        public Word() { }
    }
}
