// Render HTML to XPS format with embedded fonts by registering custom font folder first.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare directories
            string baseDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Data");
            System.IO.Directory.CreateDirectory(baseDir);

            // Create sample HTML file
            string htmlPath = System.IO.Path.Combine(baseDir, "sample.html");
            string htmlContent = "<!DOCTYPE html><html><head><meta charset='utf-8'><title>Test</title></head><body><p style='font-family: \"CustomFont\";'>Hello, XPS with embedded fonts!</p></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            // Create custom fonts folder (populate with fonts as needed)
            string fontFolder = System.IO.Path.Combine(baseDir, "fonts");
            System.IO.Directory.CreateDirectory(fontFolder);

            // Configure Aspose.HTML and register custom fonts folder with embedding enabled
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService service = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            service.FontsSettings.SetFontsLookupFolder(fontFolder, true);

            // Load HTML document with the configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration);

            // Set XPS save options
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            // Define output path
            string outputPath = System.IO.Path.Combine(baseDir, "output.xps");

            // Convert HTML to XPS
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("XPS file saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}