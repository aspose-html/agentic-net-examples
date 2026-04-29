// Create a unit test that verifies Markdown blockquote conversion to HTML and then to PNG.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare markdown content containing a blockquote
            string markdownPath = Path.Combine(Path.GetTempPath(), "blockquote.md");
            string markdownContent = @"> This is a blockquote
> spanning multiple lines.";
            File.WriteAllText(markdownPath, markdownContent);

            // Define output PNG path
            string pngPath = Path.Combine(Path.GetTempPath(), "blockquote.png");

            // Convert markdown file to an HTMLDocument
            HTMLDocument document = Converter.ConvertMarkdown(markdownPath);

            // Set up default image save options (PNG format by default)
            ImageSaveOptions options = new ImageSaveOptions();

            // Render the HTMLDocument to a PNG image
            Converter.ConvertHTML(document, options, pngPath);

            // Verify that the PNG file was created and has content
            if (File.Exists(pngPath) && new FileInfo(pngPath).Length > 0)
            {
                Console.WriteLine("Test passed: PNG image generated successfully.");
            }
            else
            {
                Console.WriteLine("Test failed: PNG image was not created.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Test failed with exception: {ex.Message}");
        }
    }
}