// Convert HTML strings directly to BMP images by passing the string and ImageSaveOptions to Converter.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, World!</h1></body></html>";
            string baseUri = "about:blank";
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            string outputPath = "output.bmp";

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine("HTML has been successfully converted to BMP image at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}