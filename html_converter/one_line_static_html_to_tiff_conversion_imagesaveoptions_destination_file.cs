// Perform a one‑line static conversion of HTML string to TIFF by providing ImageSaveOptions and destination file.

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
            string html = "<html><body><h1>Hello, TIFF!</h1></body></html>";
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
            Converter.ConvertHTML(html, ".", options, "output.tiff");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}