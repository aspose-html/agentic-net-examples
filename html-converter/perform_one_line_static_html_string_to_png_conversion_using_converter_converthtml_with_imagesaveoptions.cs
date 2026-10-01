// Perform a one‑line static conversion of HTML string to PNG by calling Converter.ConvertHTML with ImageSaveOptions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello World</h1></body></html>";
            string baseUrl = "";
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            string outputPath = "output.png";
            Aspose.Html.Converters.Converter.ConvertHTML(html, baseUrl, options, outputPath);
            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}