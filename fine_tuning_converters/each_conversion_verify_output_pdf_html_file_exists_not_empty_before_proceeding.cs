// After each conversion, verify that the output PDF or HTML file exists and is not empty before proceeding.

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
            // Define source HTML file and destination PDF file paths
            string inputPath = "input.html";
            string outputPath = "output.pdf";

            // Create configuration and enable script sandboxing (scripts will not be executed)
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // Load the HTML document with the specified configuration
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(inputPath, config);

            // Initialize default PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Perform the conversion from HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(doc, options, outputPath);

            // Verify that the PDF file was created and is not empty
            if (!File.Exists(outputPath) || new FileInfo(outputPath).Length == 0)
            {
                throw new Exception("PDF conversion failed or the output file is empty.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}