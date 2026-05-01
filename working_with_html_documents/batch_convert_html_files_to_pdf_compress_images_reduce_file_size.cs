// Batch convert a set of HTML files to PDF, compressing images to reduce overall file size.

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
            // Input and output folders
            string inputFolder = "input";
            string outputFolder = "output";
            Directory.CreateDirectory(outputFolder);

            // Process each HTML file in the input folder
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // Configure PDF save options
                    PdfSaveOptions options = new PdfSaveOptions();
                    options.HorizontalResolution = 150; // DPI
                    options.VerticalResolution = 150;   // DPI
                    options.BackgroundColor = System.Drawing.Color.LightGray;
                    options.JpegQuality = 70; // Reduce image quality to compress size

                    // Set page size and margins
                    Page page = new Page(
                        new Size(600, 800),               // Width, Height in points
                        new Margin(20, 20, 20, 20));      // Top, Right, Bottom, Left margins
                    options.PageSetup.AnyPage = page;

                    // Determine output PDF path
                    string outputPath = Path.Combine(
                        outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".pdf");

                    // Convert HTML to PDF
                    Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}