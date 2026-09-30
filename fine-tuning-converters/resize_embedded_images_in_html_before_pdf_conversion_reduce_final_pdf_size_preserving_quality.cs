// Resize embedded images in HTML before PDF conversion to reduce final PDF size while preserving quality.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string htmlPath = "input.html";
            string outputPath = "output.pdf";

            // Create a minimal HTML file if it does not exist
            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Sample Document</h1><img src='https://via.placeholder.com/800x600' /></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure PDF save options to resize images
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 150; // DPI
            options.VerticalResolution = 150;   // DPI
            options.JpegQuality = 80;           // Quality (0-100)
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            // Convert HTML to PDF with the specified options
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}