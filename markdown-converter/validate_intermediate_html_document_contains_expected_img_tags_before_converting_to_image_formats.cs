// Validate that the intermediate HTMLDocument contains expected <img> tags before converting to image formats.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Sample</h1><img src='https://example.com/image.png' alt='test'></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);
            var imgElements = document.GetElementsByTagName("img");
            if (imgElements == null || imgElements.Length == 0)
            {
                System.Console.WriteLine("No <img> tags found. Conversion aborted.");
                return;
            }
            System.Console.WriteLine($"Found {imgElements.Length} <img> tag(s). Proceeding with conversion.");
            string outputPath = "output.jpg";
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            System.Console.WriteLine($"Conversion completed. Image saved to {outputPath}");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}