// Override default DPI to 72 when generating low‑resolution PNG previews of HTML content.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file
            string inputPath = "sample.html";
            System.IO.File.WriteAllText(inputPath, "<html><body><h1>Hello World</h1></body></html>");

            // Read HTML content and determine base URI
            string htmlContent = System.IO.File.ReadAllText(inputPath);
            string baseUri = new System.Uri(System.IO.Path.GetFullPath(inputPath)).AbsoluteUri;

            // Configure image save options with 72 DPI
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.HorizontalResolution = 72;
            options.VerticalResolution = 72;

            // Convert HTML to low‑resolution PNG preview
            string outputPath = "preview.png";
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine("PNG preview saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}