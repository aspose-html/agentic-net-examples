// Configure DocRenderingOptions to set page orientation to Landscape and apply 0.75‑inch margins on all sides.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlPath = "sample.html";
            File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure DOC save options with landscape orientation and 0.75‑inch margins
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            // Margins (0.75 inches on all sides)
            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(0.75),
                Aspose.Html.Drawing.Length.FromInches(0.75),
                Aspose.Html.Drawing.Length.FromInches(0.75),
                Aspose.Html.Drawing.Length.FromInches(0.75)
            );

            // Landscape page size (A4 landscape: 842 x 595 points)
            Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(842, 595);

            // Page setup
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
            options.PageSetup.AnyPage = page;

            // Output DOC file path
            string outputPath = "output.docx";

            // Convert HTML to DOC
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}