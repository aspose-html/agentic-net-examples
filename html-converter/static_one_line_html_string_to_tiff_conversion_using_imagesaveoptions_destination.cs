// Perform a one‑line static conversion of HTML string to TIFF by providing ImageSaveOptions and destination file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.Converters.Converter.ConvertHTML(
                new Aspose.Html.HTMLDocument("<html><body><h1>Hello, World!</h1></body></html>"),
                new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff),
                "output.tiff");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}