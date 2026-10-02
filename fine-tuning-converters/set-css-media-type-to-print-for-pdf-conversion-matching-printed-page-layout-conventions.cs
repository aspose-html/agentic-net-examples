// Set CSS media type to Print for PDF conversion to match printed page layout conventions.

using System;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with print-specific CSS
            string htmlContent = @"
                <html>
                <head>
                    <style>
                        body { font-family: Arial; margin: 20px; }
                        @media print {
                            body { color: blue; }
                        }
                    </style>
                </head>
                <body>
                    <h1>Hello, Aspose.HTML!</h1>
                    <p>This text will appear blue when rendered for print.</p>
                </body>
                </html>";

            // Load HTML from string (base URI is not needed for this example)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.AliceBlue;
            options.JpegQuality = 90;

            // Optional: set page size and margins
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(595, 842), // A4 size in points
                new Aspose.Html.Drawing.Margin(40, 40, 40, 40));
            options.PageSetup.AnyPage = page;

            // Convert HTML to PDF
            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PDF conversion completed successfully. Output file: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during PDF conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}