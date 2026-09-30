// Convert HTML to JPG while preserving original aspect ratio by not specifying explicit width or height.

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Define input and output paths
                string htmlPath = "sample.html";
                string outputPath = "output.jpg";

                // Create a minimal HTML file if it does not exist
                if (!System.IO.File.Exists(htmlPath))
                {
                    System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello, Aspose.HTML!</h1><p>Sample content for conversion.</p></body></html>");
                }

                // Configure image save options (no explicit width/height to preserve aspect ratio)
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;

                // Load the HTML document
                var document = new Aspose.Html.HTMLDocument(htmlPath);

                // Convert HTML to JPEG
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}