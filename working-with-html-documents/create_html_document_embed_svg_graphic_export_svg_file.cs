// Create an HTML document, embed an SVG graphic, and export the result as an SVG file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello Aspose.HTML</h1></body></html>";

            // Base URI required by HTMLDocument constructor
            Aspose.Html.Url baseUri = new Aspose.Html.Url("file:///");

            // Create HTML document from the string content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Define temporary SVG file path
            string tempSvgPath = Path.Combine(Path.GetTempPath(), "temp_output.svg");
            document.Save(tempSvgPath);

            // Load the generated SVG document
            Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(tempSvgPath);

            // Save SVG with explicit options (optional)
            string finalSvgPath = Path.Combine(Directory.GetCurrentDirectory(), "result.svg");
            Aspose.Html.Dom.Svg.Saving.SVGSaveOptions svgOptions = new Aspose.Html.Dom.Svg.Saving.SVGSaveOptions();
            svgDoc.Save(finalSvgPath, svgOptions);

            // Convert the SVG to a JPEG image
            string jpegPath = Path.Combine(Directory.GetCurrentDirectory(), "result.jpg");
            Aspose.Html.Saving.ImageSaveOptions imgOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            // Use the SVG markup as input for conversion
            string svgMarkup = File.ReadAllText(finalSvgPath);
            Aspose.Html.Converters.Converter.ConvertSVG(svgMarkup, "", imgOptions, jpegPath);

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine($"SVG saved to: {finalSvgPath}");
            Console.WriteLine($"JPEG saved to: {jpegPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}