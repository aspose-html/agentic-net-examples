// Add a configuration flag to enable or disable intermediate HTML file generation during conversion pipelines.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Configuration flag to control intermediate HTML generation
            bool enableIntermediateHtml = true;

            // Prepare sample HTML content and source file
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello Aspose.HTML</h1></body></html>";
            string sourcePath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(sourcePath, htmlContent);

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath))
            {
                // Optionally save intermediate HTML file
                if (enableIntermediateHtml)
                {
                    string intermediatePath = Path.Combine(Path.GetTempPath(), "intermediate.html");
                    document.Save(intermediatePath, new Aspose.Html.Saving.HTMLSaveOptions());
                }

                // Convert to PDF
                string outputPath = Path.Combine(Path.GetTempPath(), "output.pdf");
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPath);

                Console.WriteLine("Conversion completed. Output file: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}