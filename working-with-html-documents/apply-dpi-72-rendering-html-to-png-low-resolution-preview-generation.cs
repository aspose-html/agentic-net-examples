// Apply a DPI of 72 when rendering HTML to PNG for low‑resolution preview generation.

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlPath = "sample.html";
                if (!System.IO.File.Exists(htmlPath))
                {
                    string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                    System.IO.File.WriteAllText(htmlPath, sampleHtml);
                }

                string htmlContent = System.IO.File.ReadAllText(htmlPath);
                string baseUri = new System.Uri(System.IO.Path.GetFullPath(htmlPath)).AbsoluteUri;

                string outputPath = "output.png";

                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                options.HorizontalResolution = 72;
                options.VerticalResolution = 72;

                Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

                System.Console.WriteLine("Conversion completed. Output saved to " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}