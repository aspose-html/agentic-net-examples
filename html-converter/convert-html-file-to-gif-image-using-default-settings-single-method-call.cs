// Convert an HTML file to a GIF image using default settings with a single method call.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlPath = "sample.html";
                string outputPath = "output.gif";

                if (!System.IO.File.Exists(htmlPath))
                {
                    System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello World</h1></body></html>");
                }

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                System.Console.WriteLine("Conversion completed successfully.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}