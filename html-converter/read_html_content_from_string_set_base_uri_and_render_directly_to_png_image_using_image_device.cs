// Read HTML content from a string, set base URI, and render directly to a PNG image using ImageDevice.

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><head><base href=\"http://example.com/\"/></head><body><h1>Hello World</h1></body></html>";
            string baseUri = "http://example.com/";
            string outputPath = "output.png";

            Aspose.Html.Rendering.Image.ImageRenderingOptions imgOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
            Aspose.Html.Rendering.Image.ImageDevice imgDevice = new Aspose.Html.Rendering.Image.ImageDevice(imgOptions, outputPath);
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUri);
            document.RenderTo(imgDevice);
            System.Console.WriteLine("Image saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}