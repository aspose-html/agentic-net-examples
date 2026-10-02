// Render the resulting HTML document to a PNG image using the RenderTo method.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlCode = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                string baseUri = "about:blank";
                Aspose.Html.HTMLDocument htmlDocument = new Aspose.Html.HTMLDocument(htmlCode, baseUri);
                string outputPath = "output.png";

                Aspose.Html.Rendering.Image.ImageRenderingOptions imgOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
                Aspose.Html.Rendering.Image.ImageDevice imgDevice = new Aspose.Html.Rendering.Image.ImageDevice(imgOptions, outputPath);
                htmlDocument.RenderTo(imgDevice);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}