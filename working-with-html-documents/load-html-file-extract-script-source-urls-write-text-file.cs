// Load an HTML file, extract all script source URLs, and write them to a text file.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output file paths
            string inputPath = "sample.html";
            string outputPath = "script-src.txt";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><script src=\"script1.js\"></script></head><body><script src='script2.js'></script></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document from file
            HTMLDocument document = new HTMLDocument(inputPath);

            // Get all <script> elements
            HTMLCollection scriptElements = document.GetElementsByTagName("script");

            // Collect src attributes
            List<string> srcList = new List<string>();
            for (int i = 0; i < scriptElements.Length; i++)
            {
                Element scriptElement = (Element)scriptElements[i];
                string src = scriptElement.GetAttribute("src");
                if (!string.IsNullOrEmpty(src))
                {
                    srcList.Add(src);
                }
            }

            // Write the collected URLs to a text file
            File.WriteAllLines(outputPath, srcList);

            Console.WriteLine("Extracted script src URLs have been written to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}