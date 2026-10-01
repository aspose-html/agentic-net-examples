// Convert an HTML file to a JPEG image with default options and write the result to disk.

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

                // Configure image save options (default JPEG)
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

                // Load the HTML document
                var document = new Aspose.Html.HTMLDocument(htmlPath);

                // Convert HTML to JPEG and save to disk
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                System.Console.WriteLine("Conversion completed. Output saved to " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}