// Read HTML content from a string, set base URI, and render directly to a PNG image using ImageDevice.

public class Program
{
    public static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUri = "about:blank";
            string outputPath = "output.png";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUri);
            Aspose.Html.Rendering.Image.ImageRenderingOptions imgOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
            Aspose.Html.Rendering.Image.ImageDevice imgDevice = new Aspose.Html.Rendering.Image.ImageDevice(imgOptions, outputPath);
            document.RenderTo(imgDevice);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}