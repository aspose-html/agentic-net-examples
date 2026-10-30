// Create an HTML document from an MHTML source, modify its title, and save as HTML.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string sourceHtmlPath = "sample.html";
            string sourceMhtmlPath = "sample.mhtml";
            string outputHtmlPath = "output.html";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(sourceHtmlPath))
            {
                File.WriteAllText(sourceHtmlPath, "<!DOCTYPE html><html><head><title>Original Title</title></head><body><p>Hello, World!</p></body></html>");
            }

            // Convert the HTML file to MHTML
            Aspose.Html.Saving.MHTMLSaveOptions mhtmlOptions = new Aspose.Html.Saving.MHTMLSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(sourceHtmlPath, mhtmlOptions, sourceMhtmlPath);

            // Load the MHTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourceMhtmlPath))
            {
                // Modify the title
                document.Title = "Modified Title";

                // Save the document as HTML
                document.Save(outputHtmlPath, Aspose.Html.Saving.HTMLSaveFormat.Original);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}