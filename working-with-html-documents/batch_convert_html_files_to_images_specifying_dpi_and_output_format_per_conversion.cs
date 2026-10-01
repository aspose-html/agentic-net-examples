// Batch convert HTML files to images, specifying DPI and output format for each conversion.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Output");
            System.IO.Directory.CreateDirectory(outputDir);

            // Create a sample HTML file
            string inputHtmlPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.html");
            string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello Aspose.HTML</h1></body></html>";
            System.IO.File.WriteAllText(inputHtmlPath, sampleHtml);

            // Load document and convert to JPEG with DPI settings
            using (var document = new Aspose.Html.HTMLDocument(inputHtmlPath, System.IO.Directory.GetCurrentDirectory()))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                string outputPath = System.IO.Path.Combine(outputDir, "sample.jpg");
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                System.Console.WriteLine($"Converted file saved to: {outputPath}");
            }

            // Convert HTML string directly to PNG
            string htmlContent = "<html><body><h2>In‑memory HTML conversion</h2></body></html>";
            string baseUri = new Uri(System.IO.Path.GetFullPath(inputHtmlPath)).AbsoluteUri;

            var stringOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            stringOptions.HorizontalResolution = 150;
            stringOptions.VerticalResolution = 150;

            string outputPathString = System.IO.Path.Combine(outputDir, "string.png");
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, stringOptions, outputPathString);
            System.Console.WriteLine($"Converted string saved to: {outputPathString}");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}