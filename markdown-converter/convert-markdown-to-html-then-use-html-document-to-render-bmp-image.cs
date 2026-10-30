// Convert Markdown to HTML and then use the HTMLDocument API to render it as a BMP image.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string markdown = "### Hello, World!\r\n[visit applications](https://products.aspose.app/html/family)";
            using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.bmp");
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                System.Console.WriteLine("Conversion completed. Image saved to: " + outputPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}