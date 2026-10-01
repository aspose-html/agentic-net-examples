// Set ImageSaveOptions.CompressionLevel to optimize GIF file size without sacrificing visual quality significantly.

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
                    System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello, GIF!</h1></body></html>");
                }

                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                System.Console.WriteLine("GIF image saved to " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}