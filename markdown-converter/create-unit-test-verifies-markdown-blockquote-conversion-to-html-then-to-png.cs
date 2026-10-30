// Create a unit test that verifies Markdown blockquote conversion to HTML and then to PNG.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare markdown source with a blockquote
            string sourcePath = "sample.md";
            string markdownContent = "> This is a blockquote";
            File.WriteAllText(sourcePath, markdownContent);

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Verify that the generated HTML contains a blockquote element
            string html = document.DocumentElement.OuterHTML;
            if (html == null || !html.Contains("<blockquote"))
                throw new InvalidOperationException("Blockquote element not found in generated HTML.");

            // Set PNG image save options
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Convert HTML to PNG
            string savePath = "output.png";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            // Verify that the PNG file was created
            if (!File.Exists(savePath))
                throw new FileNotFoundException("PNG output file was not created.", savePath);

            Console.WriteLine("Markdown blockquote conversion to HTML and PNG succeeded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}