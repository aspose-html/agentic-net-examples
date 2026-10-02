// Convert 1024 pixel width to points and use the result to set graphic width in PDF.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Convert 1024 pixels to points
            double borderPixels = 1024.0;
            double borderPoints = borderPixels * 72.0 / 96.0;
            System.Console.WriteLine($"1024 pixels = {borderPoints:F2} points");

            // Prepare simple HTML with a div whose width is set in points
            string htmlContent = $"<html><body><div id=\"box\" style=\"border:1pt solid red; width:{borderPoints:F2}pt; height:100pt; background-color:lightgray;\"></div></body></html>";

            // Load HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Render to PDF
            string outputPath = "output.pdf";
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            System.Console.WriteLine($"PDF generated at: {outputPath}");
        }
        catch (Exception ex)
        {
            System.Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}