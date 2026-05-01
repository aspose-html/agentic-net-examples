// Load an HTML file, extract all script source URLs, and write them to a text file.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the HTML file to be processed
            string htmlPath = "input.html";

            // Path where the extracted script src URLs will be saved
            string outputPath = "script-src.txt";

            // Load the HTML document (rule: extract-script-src-urls-with-dom-element-cast)
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Retrieve all <script> elements
            HTMLCollection scriptElements = document.GetElementsByTagName("script");

            // Collect non‑empty src attributes
            List<string> srcList = new List<string>();

            for (int i = 0; i < scriptElements.Length; i++)
            {
                // Cast each node to Element to access attributes
                Element scriptElement = (Element)scriptElements[i];

                // Get the value of the src attribute
                string src = scriptElement.GetAttribute("src");

                if (!string.IsNullOrEmpty(src))
                {
                    srcList.Add(src);
                }
            }

            // Write the collected URLs to a text file, one per line
            File.WriteAllLines(outputPath, srcList);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}