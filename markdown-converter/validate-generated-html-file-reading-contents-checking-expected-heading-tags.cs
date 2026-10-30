// Validate the generated HTML file by reading its contents and checking for expected heading tags.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define the path for the sample HTML file
            string htmlFilePath = "sample.html";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlFilePath))
            {
                string sampleContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Title</h1><h2>Subtitle</h2></body></html>";
                File.WriteAllText(htmlFilePath, sampleContent);
            }

            // Load the HTML document from the file
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFilePath);

            // Retrieve heading elements
            Aspose.Html.Collections.HTMLCollection h1Elements = document.GetElementsByTagName("h1");
            Aspose.Html.Collections.HTMLCollection h2Elements = document.GetElementsByTagName("h2");

            // Validate presence of expected headings
            bool hasH1 = h1Elements != null && h1Elements.Length > 0;
            bool hasH2 = h2Elements != null && h2Elements.Length > 0;

            // Output validation results
            Console.WriteLine("HTML Validation Results:");
            Console.WriteLine($"- <h1> present: {hasH1}");
            Console.WriteLine($"- <h2> present: {hasH2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}