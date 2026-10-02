// Set image width and height in ImageSaveOptions when converting Markdown to a PNG file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a sample markdown file
            string sourcePath = "sample.md";
            string markdownContent = "# Sample Markdown\nThis is a sample markdown file for conversion.";
            System.IO.File.WriteAllText(sourcePath, markdownContent);

            // Define output PNG path
            string savePath = "output.png";

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Configure image save options with desired dimensions
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(800, 600),               // Width = 800px, Height = 600px
                new Aspose.Html.Drawing.Margin(0, 0, 0, 0)            // No margins
            );

            // Convert HTMLDocument to PNG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("Markdown has been successfully converted to PNG at: " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}