// Convert HTML to JPEG with quality level 80 by configuring Quality property in ImageSaveOptions.

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
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            string baseUri = ".";
            string outputPath = "output.jpg";

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            var qualityProp = typeof(ImageSaveOptions).GetProperty("Quality");
            if (qualityProp != null && qualityProp.CanWrite)
            {
                qualityProp.SetValue(options, 80);
            }

            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}