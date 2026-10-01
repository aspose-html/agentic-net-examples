// Convert an HTML file to a TIFF image using default settings and saving to a specified output file.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlPath = "sample.html";
                string outputPath = "output.tiff";

                if (!System.IO.File.Exists(htmlPath))
                {
                    System.IO.File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, World!</h1></body></html>");
                }

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}