// Configure ImageSaveOptions to embed color profiles in the resulting GIF for accurate color representation.

namespace AsposeHtmlGifExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "sample.html";
                string outputPath = "output.gif";

                if (!System.IO.File.Exists(htmlPath))
                {
                    System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello GIF</h1></body></html>");
                }

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                // Color profile embedding is not supported directly; using default options.

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                System.Console.WriteLine("Conversion completed: " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}