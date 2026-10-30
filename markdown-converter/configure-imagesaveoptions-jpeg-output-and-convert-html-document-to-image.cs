// Configure ImageSaveOptions for JPEG output and convert an HTML document to an image.

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define input and output paths
                string htmlPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.html");
                string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.jpg");

                // Create a minimal HTML file if it does not exist
                if (!System.IO.File.Exists(htmlPath))
                {
                    string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                    System.IO.File.WriteAllText(htmlPath, htmlContent);
                }

                // Configure image save options for JPEG
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Load the HTML document
                var document = new Aspose.Html.HTMLDocument(htmlPath);

                // Convert HTML to JPEG image
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}