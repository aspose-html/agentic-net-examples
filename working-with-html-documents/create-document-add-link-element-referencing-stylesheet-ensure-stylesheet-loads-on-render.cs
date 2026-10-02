// Create a document, add a link element referencing a stylesheet, and ensure stylesheet loads on render.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare temporary folder
            string tempFolder = Path.Combine(Directory.GetCurrentDirectory(), "temp");
            Directory.CreateDirectory(tempFolder);

            // Create stylesheet file
            string cssPath = Path.Combine(tempFolder, "style.css");
            File.WriteAllText(cssPath, "body { background-color: lightblue; }");

            // HTML content referencing the stylesheet
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"style.css\"/></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Base URI pointing to the temporary folder
            string baseUri = new Uri(tempFolder + Path.DirectorySeparatorChar).AbsoluteUri;

            // Load HTML document with base URI so the stylesheet can be resolved
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Convert to PDF to ensure stylesheet is applied during rendering
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
            Aspose.Html.Saving.PdfSaveOptions saveOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, saveOptions, outputPath);

            Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}