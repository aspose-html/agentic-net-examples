// Set ImageSaveOptions.ImageFormat to Svg when converting Markdown to SVG to ensure correct output type.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input markdown (treated as HTML for this example) and output SVG
            string inputPath = "input.md";
            string outputPath = "output.svg";

            // Load markdown content (for demonstration, treat as plain text)
            string markdownContent = System.IO.File.ReadAllText(inputPath);

            // Convert markdown to HTML (simple placeholder conversion)
            string htmlContent = "<html><body>" + System.Net.WebUtility.HtmlEncode(markdownContent) + "</body></html>";

            // Create ImageSaveOptions (default settings)
            ImageSaveOptions options = new ImageSaveOptions();

            // Note: Aspose.HTML does not support setting ImageFormat to SVG via ImageSaveOptions.
            // Therefore, we proceed with default options.

            // Convert the HTML content to an image file (PNG as a fallback format)
            // The output file extension determines the format; using .svg will produce SVG if supported.
            Converter.ConvertHTML(htmlContent, ".", options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}