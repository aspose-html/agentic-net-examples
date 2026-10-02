// Convert a list of HTML sources to MHTML outputs using MHTMLSaveOptions within a foreach loop.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML files
            string[] htmlSources = new string[] { "sample1.html", "sample2.html" };
            string[] htmlContents = new string[]
            {
                "<!DOCTYPE html><html><head><title>Sample 1</title></head><body><h1>First Sample</h1></body></html>",
                "<!DOCTYPE html><html><head><title>Sample 2</title></head><body><h1>Second Sample</h1></body></html>"
            };

            for (int i = 0; i < htmlSources.Length; i++)
            {
                File.WriteAllText(htmlSources[i], htmlContents[i]);
            }

            // Convert each HTML file to MHTML
            foreach (string sourcePath in htmlSources)
            {
                // Load HTML document from file
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);

                // Configure MHTML save options
                Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();

                // Determine output MHTML file path
                string outputPath = Path.ChangeExtension(sourcePath, ".mhtml");

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine($"Converted '{sourcePath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}