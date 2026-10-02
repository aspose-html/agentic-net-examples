// Configure ImageSaveOptions for JPEG output and convert an HTML document to an image.

namespace Example
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
                    System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
                }

                // Configure image save options for JPEG
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Load the HTML document
                var document = new Aspose.Html.HTMLDocument(htmlPath);

                // Convert HTML to JPEG image
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                System.Console.WriteLine("Conversion completed: " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}