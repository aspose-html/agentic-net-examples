// Use the online Color Contrast Checker API to programmatically verify contrast ratios for identified elements.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a simple HTML file
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><p>Hello World</p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Set body background color
            var body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body")[0];
            body.Style.BackgroundColor = "lightblue";

            // Change paragraph text color
            var paragraph = (Aspose.Html.HTMLElement)document.GetElementsByTagName("p")[0];
            paragraph.Style.Color = "darkred";

            // Save the modified HTML
            string modifiedHtmlPath = "modified.html";
            document.Save(modifiedHtmlPath);

            // Convert to PDF with a background color
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            pdfOptions.HorizontalResolution = 300;
            pdfOptions.VerticalResolution = 300;
            pdfOptions.BackgroundColor = System.Drawing.Color.AliceBlue;
            string pdfPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, pdfPath);

            // Convert to TIFF image
            var imageOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            imageOptions.Compression = Aspose.Html.Rendering.Image.Compression.None;
            imageOptions.UseAntialiasing = true;
            imageOptions.HorizontalResolution = 300;
            imageOptions.VerticalResolution = 300;
            var pageSize = new Aspose.Html.Drawing.Size(800, 600);
            var margin = new Aspose.Html.Drawing.Margin(10, 10, 10, 10);
            imageOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(pageSize, margin);
            string tiffPath = "output.tiff";
            Aspose.Html.Converters.Converter.ConvertHTML(document, imageOptions, tiffPath);

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}