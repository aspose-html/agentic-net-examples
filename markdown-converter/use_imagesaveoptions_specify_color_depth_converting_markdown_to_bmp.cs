// Use ImageSaveOptions to specify color depth when converting Markdown to BMP format.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare markdown content
            string markdownContent = "### Hello, World!\r\n[visit applications](https://products.aspose.app/html/family)";
            string markdownPath = Path.Combine(Environment.CurrentDirectory, "sample.md");
            File.WriteAllText(markdownPath, markdownContent);

            // Convert markdown to HTML document
            using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath))
            {
                // Set image save options for BMP format
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                // Example option settings (optional)
                options.UseAntialiasing = false;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = System.Drawing.Color.Beige;

                // Prepare output path
                string outputDir = Path.Combine(Environment.CurrentDirectory, "Output");
                Directory.CreateDirectory(outputDir);
                string outputPath = Path.Combine(outputDir, "output.bmp");

                // Convert HTML to BMP image
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                Console.WriteLine($"Markdown has been converted to BMP image at: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}