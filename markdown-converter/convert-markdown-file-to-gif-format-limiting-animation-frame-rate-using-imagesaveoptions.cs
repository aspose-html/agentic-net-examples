// Convert a Markdown file to GIF format while limiting the animation frame rate using ImageSaveOptions.

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.md";
            string markdownContent = "# Sample Markdown\n\nThis is a sample markdown file converted to GIF.";
            System.IO.File.WriteAllText(sourcePath, markdownContent);

            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            // Note: Limiting GIF animation frame rate is not supported by ImageSaveOptions.

            string savePath = "output.gif";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            System.Console.WriteLine("Conversion completed. GIF saved to: " + savePath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}