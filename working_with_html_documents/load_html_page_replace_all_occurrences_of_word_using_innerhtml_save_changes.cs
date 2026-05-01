// Load an HTML page, replace all occurrences of a word using innerHTML, and save changes.

using System;
using Aspose.Html;

namespace ReplaceWordExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";
                string wordToReplace = "oldWord";
                string replacement = "newWord";

                HTMLDocument document = new HTMLDocument(inputPath);
                document.Body.InnerHTML = document.Body.InnerHTML.Replace(wordToReplace, replacement);
                document.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}