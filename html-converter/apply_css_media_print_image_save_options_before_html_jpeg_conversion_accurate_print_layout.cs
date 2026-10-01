// Apply CSS media type “print” in ImageSaveOptions before converting HTML to JPEG for accurate print layout.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string htmlPath = "sample.html";
            string outputPath = "output.jpg";

            // Create a minimal HTML file if it does not exist
            if (!System.IO.File.Exists(htmlPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><style>@media print { body { font-size: 20px; } }</style></head><body><h1>Hello, Print Layout!</h1></body></html>";
                System.IO.File.WriteAllText(htmlPath, sampleHtml);
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure image save options with print media type
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.Css.MediaType = Aspose.Html.Rendering.MediaType.Print;

            // Convert HTML to JPEG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            System.Console.WriteLine("HTML has been successfully converted to JPEG at: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}