// Implement a feature that allows users to specify image DPI in ImageSaveOptions for PNG output.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            string inputPath = "sample.html";
            System.IO.File.WriteAllText(inputPath, htmlContent);
            string outputPath = "output.png";

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
            options.Format = Aspose.Html.Rendering.Image.ImageFormat.Png;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            Aspose.Html.Converters.Converter.ConvertHTML(inputPath, options, outputPath);

            Console.WriteLine("Image saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}