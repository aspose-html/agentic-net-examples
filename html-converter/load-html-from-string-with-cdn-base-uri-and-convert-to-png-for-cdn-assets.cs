// Load HTML from a string with CDN base URI and convert to PNG for CDN assets.

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"styles.css\"></head><body><img src=\"images/logo.png\"/></body></html>";
            string baseUri = "https://cdn.example.com/";
            string outputPath = "output.png";

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            Aspose.Html.Converters.Converter.ConvertHTML(html, baseUri, options, outputPath);

            System.Console.WriteLine("Conversion completed. Output saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}