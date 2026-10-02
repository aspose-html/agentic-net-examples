// Load an HTML file, extract all script source URLs, and write them to a text file.

using System;
using System.Collections.Generic;
using System.IO;

namespace AsposeHtmlScriptExtractor
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.html";
                string outputPath = "script-src.txt";

                // Create a minimal sample HTML file if it does not exist
                if (!File.Exists(inputPath))
                {
                    string sampleHtml = "<html><head><script src=\"https://example.com/script1.js\"></script></head><body><script src='script2.js'></script></body></html>";
                    File.WriteAllText(inputPath, sampleHtml);
                }

                // Load the HTML document from the file
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

                // Get all <script> elements
                Aspose.Html.Collections.HTMLCollection scriptElements = document.GetElementsByTagName("script");

                List<string> srcList = new List<string>();

                for (int i = 0; i < scriptElements.Length; i++)
                {
                    Aspose.Html.Dom.Element scriptElement = (Aspose.Html.Dom.Element)scriptElements[i];
                    string src = scriptElement.GetAttribute("src");
                    if (!string.IsNullOrEmpty(src))
                    {
                        Console.WriteLine(src);
                        srcList.Add(src);
                    }
                }

                // Write the extracted src URLs to a text file
                File.WriteAllLines(outputPath, srcList);
                Console.WriteLine($"Script source URLs have been written to '{outputPath}'.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}