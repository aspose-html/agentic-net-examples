// Configure sandbox to allow images, disable scripts, load a page, and verify only images appear.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlPath = Path.Combine(Path.GetTempPath(), "sample.html");
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <script>console.log('This script should be blocked');</script>
</head>
<body>
    <img src='https://via.placeholder.com/150' alt='Sample Image' />
    <p>Some text content.</p>
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Configure sandbox: allow images, do not allow scripts
            var config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Images; // allow images
            // Scripts flag is not set, so scripts are disabled

            // Load the HTML document with the sandbox configuration
            using (var document = new Aspose.Html.HTMLDocument(htmlPath, config))
            {
                // Verify that only images are present (scripts should be blocked)
                var images = document.QuerySelectorAll("img");
                var scripts = document.QuerySelectorAll("script");

                Console.WriteLine($"Images found: {images.Length}");
                Console.WriteLine($"Scripts found (should be 0): {scripts.Length}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}