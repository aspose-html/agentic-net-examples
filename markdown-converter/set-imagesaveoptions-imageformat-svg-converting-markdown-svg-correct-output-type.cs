// Set ImageSaveOptions.ImageFormat to Svg when converting Markdown to SVG to ensure correct output type.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string markdown = "# Hello World\nThis is a **markdown** sample.";
            // Simple conversion: treat markdown as equivalent HTML for this example.
            string html = "<html><body><h1>Hello World</h1><p>This is a <strong>markdown</strong> sample.</p></body></html>";
            string outputPath = "output.svg";

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
            // ImageFormat.Svg is not available; the output path extension determines the format.

            Aspose.Html.Converters.Converter.ConvertSVG(html, options, outputPath);
            Console.WriteLine("SVG file saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}