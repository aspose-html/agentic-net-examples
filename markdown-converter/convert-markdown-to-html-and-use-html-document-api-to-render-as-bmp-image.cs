// Convert Markdown to HTML and then use the HTMLDocument API to render it as a BMP image.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            string markdownPath = Path.Combine(outputDir, "sample.md");
            string markdownContent = "### Hello, World!\r\n[visit applications](https://products.aspose.app/html/family)";
            File.WriteAllText(markdownPath, markdownContent);

            using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                string imagePath = Path.Combine(outputDir, "output.bmp");
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, imagePath);
                Console.WriteLine($"Image saved to: {imagePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}