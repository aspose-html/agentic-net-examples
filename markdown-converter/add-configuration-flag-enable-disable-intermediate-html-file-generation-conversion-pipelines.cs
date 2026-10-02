// Add a configuration flag to enable or disable intermediate HTML file generation during conversion pipelines.

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
            // Configuration flag to control intermediate HTML generation
            bool generateIntermediate = true;

            // Prepare sample HTML file
            string sourcePath = "sample.html";
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            File.WriteAllText(sourcePath, htmlContent);

            // Create Aspose HTML configuration
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();

            // Load HTML document from file
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(sourcePath, config);

            if (generateIntermediate)
            {
                // Generate intermediate MHTML file
                string intermediatePath = "intermediate.mhtml";
                Aspose.Html.Saving.MHTMLSaveOptions mhtmlOptions = new Aspose.Html.Saving.MHTMLSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(doc, mhtmlOptions, intermediatePath);

                // Convert intermediate MHTML to DOC
                using (Stream mhtmlStream = File.OpenRead(intermediatePath))
                {
                    string finalDocPath = "output.doc";
                    Aspose.Html.Converters.Converter.ConvertMHTML(mhtmlStream, new Aspose.Html.Saving.DocSaveOptions(), finalDocPath);
                    Console.WriteLine($"Intermediate MHTML generated and converted to DOC: {finalDocPath}");
                }
            }
            else
            {
                // Direct conversion to PDF without intermediate file
                string finalPdfPath = "output.pdf";
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(doc, pdfOptions, finalPdfPath);
                Console.WriteLine($"HTML directly converted to PDF: {finalPdfPath}");
            }

            // Cleanup temporary files
            if (File.Exists(sourcePath)) File.Delete(sourcePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}