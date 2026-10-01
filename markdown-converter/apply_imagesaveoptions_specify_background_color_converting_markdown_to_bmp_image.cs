// Apply ImageSaveOptions to specify background color when converting Markdown to a BMP image.

using System;
using System.IO;
using System.Drawing;

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
                options.BackgroundColor = System.Drawing.Color.Beige;

                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.bmp");
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine("Conversion completed. Image saved to: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}