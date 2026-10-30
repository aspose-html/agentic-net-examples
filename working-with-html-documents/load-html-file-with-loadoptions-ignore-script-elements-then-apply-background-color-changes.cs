// Load an HTML file with LoadOptions that ignore script elements, then apply background color changes.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal HTML file with a script element if it doesn't exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
    <script>console.log('This script will be ignored');</script>
</head>
<body>
    <p>Hello, World!</p>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Configure to ignore script execution
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security = Aspose.Html.Sandbox.None; // disable all sandboxed features, including scripts

            // Load the HTML document with the configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, config);

            // Access the <body> element and change its background color
            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body").First();
            body.Style.BackgroundColor = "lightblue";

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine($"Document processed and saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}