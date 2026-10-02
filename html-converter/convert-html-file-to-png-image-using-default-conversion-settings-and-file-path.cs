// Convert an HTML file to a PNG image using default conversion settings and a file path.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlPath = "sample.html";
                string outputPath = "output.png";

                if (!System.IO.File.Exists(htmlPath))
                {
                    System.IO.File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
                }

                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                var document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}