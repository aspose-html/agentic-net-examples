// Create an ImageDevice for JPG output with a black background by setting RenderingOptions.BackgroundColor.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, "about:blank");

            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.Black;

            string outputPath = "output.jpg";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}