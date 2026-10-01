// Apply a custom font family to all headings, then render the document to XPS format.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
    <style>
        h1 { color: navy; }
    </style>
</head>
<body>
    <h1>Hello Aspose.HTML</h1>
</body>
</html>";

            // Create a temporary HTML file
            string inputPath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(inputPath, htmlContent);

            // Initialize Aspose.HTML configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Set a user‑agent style sheet
            Aspose.Html.Services.IUserAgentService userAgent = configuration.GetService<Aspose.Html.Services.IUserAgentService>();
            userAgent.UserStyleSheet = "body { background-color: #f0f0f0; }";

            // Load the HTML document with the configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration);

            // Prepare XPS save options
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            // Define output path
            string outputPath = Path.Combine(Path.GetTempPath(), "output.xps");

            // Convert HTML to XPS
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Conversion succeeded. XPS saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}