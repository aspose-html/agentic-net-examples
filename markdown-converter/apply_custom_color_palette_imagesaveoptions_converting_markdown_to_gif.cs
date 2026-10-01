// Apply a custom color palette in ImageSaveOptions when converting Markdown to GIF format.

using System;

namespace AsposeHtmlMarkdownToGif
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Sample markdown content
                string markdown = "# Sample Title\nThis is a **markdown** example.";

                // Convert markdown to HTMLDocument
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown);

                // Set image save options for GIF format
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(
                    Aspose.Html.Rendering.Image.ImageFormat.Gif);

                // Note: ImageSaveOptions does not expose a ColorPalette property in the current API,
                // so a custom palette cannot be set directly.

                // Output file path
                string outputPath = "output.gif";

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine("Markdown has been converted to GIF successfully: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}