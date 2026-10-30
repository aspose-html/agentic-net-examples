// Set the compression level in ImageSaveOptions when converting Markdown to PNG for web optimization.

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a sample markdown file
                string sourcePath = "sample.md";
                string markdownContent = "# Hello World\nThis is a sample markdown.";
                System.IO.File.WriteAllText(sourcePath, markdownContent);

                // Convert markdown to HTMLDocument
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

                // Configure image save options for PNG
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;

                // Convert HTML to PNG
                string outputPath = "output.png";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}