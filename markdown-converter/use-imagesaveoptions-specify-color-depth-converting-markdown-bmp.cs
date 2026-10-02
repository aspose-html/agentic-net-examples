// Use ImageSaveOptions to specify color depth when converting Markdown to BMP format.

public class Program
{
    public static void Main()
    {
        try
        {
            string markdownPath = "sample.md";
            string markdownContent = "### Hello, World!\r\n[visit applications](https://products.aspose.app/html/family)";
            System.IO.File.WriteAllText(markdownPath, markdownContent);

            using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                string outputPath = "output.bmp";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                System.Console.WriteLine("Conversion completed. Output saved to " + outputPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}