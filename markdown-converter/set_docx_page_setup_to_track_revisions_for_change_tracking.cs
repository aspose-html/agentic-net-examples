// Set DOCX page setup to track revisions using DocSaveOptions.TrackRevisions for change tracking.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content
            string sourcePath = "sample.html";
            string htmlContent = "<html><body><p>Hello World</p></body></html>";
            File.WriteAllText(sourcePath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);

            // Set DOCX save options (TrackRevisions property is not available in the API)
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            // Define output DOCX file path
            string outputPath = "output.docx";

            // Convert HTML to DOCX
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}