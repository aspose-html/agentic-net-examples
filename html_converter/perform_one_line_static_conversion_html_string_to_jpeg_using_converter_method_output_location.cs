// Perform a one‑line static conversion of HTML string to JPEG using static Converter method and output location.

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
            string htmlContent = "<h1>Convert HTML to JPG File Format!</h1>";
            string baseUri = ".";
            string outputPath = "output.jpg";
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}