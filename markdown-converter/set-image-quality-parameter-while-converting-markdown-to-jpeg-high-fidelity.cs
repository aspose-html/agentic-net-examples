// Set image quality parameter in ImageSaveOptions while converting Markdown to JPEG with high fidelity.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input markdown file and output image path
            string sourcePath = "sample.md";
            string outputPath = "output.jpg";

            // Create a minimal markdown file
            string markdownContent = "# Sample Title\nThis is a sample markdown document.\n\n- First item\n- Second item";
            System.IO.File.WriteAllText(sourcePath, markdownContent);

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Configure image save options for high fidelity JPEG
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.UseAntialiasing = true;

            // Perform conversion to JPEG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Markdown successfully converted to JPEG: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}