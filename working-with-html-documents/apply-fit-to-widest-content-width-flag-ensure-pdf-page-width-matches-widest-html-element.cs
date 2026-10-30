// Apply FitToWidestContentWidth flag to ensure PDF page width matches the widest element in HTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            // Create a minimal HTML file with a wide element if it doesn't exist
            if (!File.Exists(htmlPath))
            {
                string htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <style>
        .wide { width: 1200px; background-color: lightblue; }
    </style>
</head>
<body>
    <div class='wide'>This div is very wide to test FitToContentWidth.</div>
</body>
</html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure PDF rendering options with FitToContentWidth
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.PageLayoutOptions = Aspose.Html.Rendering.PageLayoutOptions.FitToContentWidth;

            // Create PDF device and render
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath);
            document.RenderTo(device);

            Console.WriteLine($"PDF successfully generated at: {Path.GetFullPath(pdfPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}