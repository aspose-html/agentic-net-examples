// Convert a Markdown string to HTML and then export the result as a TIFF file with compression.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string markdown = "# Sample Title\n\nThis is a **markdown** text.";
            string tempMdPath = Path.Combine(Path.GetTempPath(), "sample.md");
            File.WriteAllText(tempMdPath, markdown);

            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(tempMdPath);

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.tiff");
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed. TIFF saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}