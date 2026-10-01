// Create a unit test that verifies Markdown blockquote conversion to HTML and then to PNG.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Markdown content with a blockquote
            string markdown = @"> This is a blockquote
>
> It spans multiple lines.

Regular paragraph text.";

            // Convert Markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown);

            // Set up PNG image save options
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(
                Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Output PNG file path
            string outputPath = "blockquote.png";

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            // Verify the PNG file was created and has content
            if (File.Exists(outputPath) && new FileInfo(outputPath).Length > 0)
            {
                Console.WriteLine("Test passed: PNG file generated successfully.");
            }
            else
            {
                Console.WriteLine("Test failed: PNG file was not generated correctly.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}