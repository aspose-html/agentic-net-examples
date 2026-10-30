// Load HTML from a URL, configure proxy settings in Configuration, and render to JPG.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define the source URL
            var sourceUrl = new Aspose.Html.Url("https://example.com");

            // Define the output file path
            string outputPath = "output.jpg";

            // Configure image save options for JPEG format
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Perform the conversion
            Aspose.Html.Converters.Converter.ConvertHTML(sourceUrl, options, outputPath);

            Console.WriteLine("HTML has been successfully rendered to JPEG.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}