// Perform a one‑line static conversion of HTML string to BMP using Converter.ConvertHTML and specifying output path.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content to be converted
            string html = "<html><body><h1>Hello, World!</h1></body></html>";

            // Configure image save options for BMP format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

            // Perform one‑line conversion of the HTML string to a BMP file
            Converter.ConvertHTML(html, "", options, "output.bmp");
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine(ex.Message);
        }
    }
}