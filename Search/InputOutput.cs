using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Search
{
    public class IO
    {
        public static string ReadFile(string fileLocation)
        {
            // code came from https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-read-text-from-a-
            try
            {   // Open the text file using a stream reader.
                StreamReader sr = new StreamReader(fileLocation);
                // Read the stream to a string.
                string fileContent = sr.ReadToEnd();
                // Return the file Content as a string
                return fileContent;
            }
            catch (IOException e)
            {
                // Write the e.Message to console 
                Console.WriteLine(e.Message);
                // Return null if file fail to read
                return null;
            }

        }


        public static void SaveFile(string file)
        {

        }
    }
}
