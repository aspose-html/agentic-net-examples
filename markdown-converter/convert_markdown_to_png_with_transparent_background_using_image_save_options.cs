// Convert Markdown to PNG with transparent background by configuring ImageSaveOptions appropriately.

class Program
{
    static void Main()
    {
        try
        {
            string markdown = "# Hello World\nThis is a **markdown** sample.";
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.BackgroundColor = System.Drawing.Color.Transparent;
            string outputPath = "output.png";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            System.Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}