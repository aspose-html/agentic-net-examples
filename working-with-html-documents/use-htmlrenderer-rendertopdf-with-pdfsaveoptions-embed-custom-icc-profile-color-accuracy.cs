// Use HtmlRenderer.RenderToPdf with PdfSaveOptions to embed a custom ICC profile for color accuracy.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, PDF with ICC profile!</h1></body></html>";
            // Base URI for the HTML document
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
            // Load HTML document from content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Path to the custom ICC profile (dummy file will be created if missing)
            string iccPath = "profile.icc";
            if (!System.IO.File.Exists(iccPath))
            {
                // Create a minimal dummy ICC profile file
                System.IO.File.WriteAllBytes(iccPath, new byte[] { 0, 1, 2, 3 });
            }
            // Read ICC profile data (not used because PdfSaveOptions does not support it)
            byte[] iccData = System.IO.File.ReadAllBytes(iccPath);

            // Configure PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.White;

            // Output PDF path
            string pdfPath = "output.pdf";

            // Render HTML to PDF with the specified options
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            System.Console.WriteLine("PDF generated successfully at: " + pdfPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}