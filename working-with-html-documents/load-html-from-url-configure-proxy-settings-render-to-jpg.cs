// Load HTML from a URL, configure proxy settings in Configuration, and render to JPG.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define output file path
            string outputPath = "output.jpg";

            // Define source URL
            var sourceUrl = new Aspose.Html.Url("https://example.com");

            // Configure image save options for JPEG format
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Convert HTML from the URL to a JPEG image file
            Aspose.Html.Converters.Converter.ConvertHTML(sourceUrl, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}