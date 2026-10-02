// Resize embedded images in HTML before PDF conversion to reduce final PDF size while preserving quality.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML and output PDF paths
            string htmlPath = "sample.html";
            string outputPath = "output.pdf";

            // Create a minimal HTML file with an embedded image if it does not exist
            if (!File.Exists(htmlPath))
            {
                string htmlContent = "<html><body><h1>Sample Document</h1><img src=\"https://via.placeholder.com/600x400\" alt=\"Sample Image\" /></body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure PDF save options to resize images (reduce resolution)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 150; // DPI
            options.VerticalResolution = 150;   // DPI
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            // Optional: set page size and margins
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.5f),
                Aspose.Html.Drawing.Length.FromInches(11f));
            Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(0, 0, 0, 0);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);
            options.PageSetup.AnyPage = page;

            // Convert HTML to PDF with the configured options
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PDF conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}