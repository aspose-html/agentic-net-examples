// Create a unit test that verifies Markdown blockquote conversion to HTML and then to PNG.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a markdown file with a blockquote
            string sourcePath = "blockquote.md";
            string markdown = @"> This is a blockquote
> spanning two lines.";
            File.WriteAllText(sourcePath, markdown);

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Verify that the HTML contains a blockquote element
            var blockquotes = document.GetElementsByTagName("blockquote");
            if (blockquotes.Length == 0)
            {
                Console.WriteLine("Blockquote element not found in the generated HTML.");
                return;
            }

            // Convert the HTMLDocument to PNG
            string outputPath = "blockquote.png";
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Conversion successful. PNG saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}