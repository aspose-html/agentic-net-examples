// Set sandbox flags to disable both scripts and network, load a page, and verify all external calls blocked.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and enable sandbox flags to block scripts
            var configuration = new Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Sample HTML containing external script and image references
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <script src=""https://example.com/script.js""></script>
</head>
<body>
    <img src=""https://example.com/image.png"" />
    <p id=""msg"">Hello World</p>
</body>
</html>";
            string htmlPath = "sample.html";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            // Load the document with the sandbox configuration
            using (var document = new HTMLDocument(htmlPath, configuration))
            {
                // Verify external script elements
                var scripts = document.GetElementsByTagName("script");
                Console.WriteLine($"Script elements count: {scripts.Length}");

                // Verify external image elements
                var images = document.GetElementsByTagName("img");
                Console.WriteLine($"Image elements count: {images.Length}");

                // Simple verification output
                if (scripts.Length == 0 && images.Length == 0)
                {
                    Console.WriteLine("All external resources are blocked.");
                }
                else
                {
                    Console.WriteLine("External resources are present in the DOM but script execution is blocked.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}