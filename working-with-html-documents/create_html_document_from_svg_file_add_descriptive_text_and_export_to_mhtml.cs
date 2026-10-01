// Create an HTML document from an SVG file, add descriptive text, and export it to MHTML.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content containing an SVG element
            string htmlContent = "<html><body><svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'><rect x='10' y='10' width='180' height='180' fill='lightblue' stroke='navy' stroke-width='4'/></svg></body></html>";

            // Base URI required by the HTMLDocument constructor
            Aspose.Html.Url baseUri = new Aspose.Html.Url("file:///");

            // Create an HTML document from the string content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Set image save options (PNG format)
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Output file path
            string outputPath = "output.png";

            // Convert the HTML document (including the SVG) to an image file
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Conversion succeeded. Image saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}