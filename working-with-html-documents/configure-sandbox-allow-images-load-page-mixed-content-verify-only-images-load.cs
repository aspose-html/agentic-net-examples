// Configure sandbox to allow images, load a page with mixed content, and verify only images load.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define HTML content with an image and a script (mixed content)
            string htmlPath = "sample.html";
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <title>Mixed Content Test</title>
    <script id='testScript' src='https://example.com/script.js'></script>
</head>
<body>
    <h1>Test Page</h1>
    <img id='testImg' src='https://example.com/image.png' alt='Test Image' />
</body>
</html>";
            // Write HTML to file
            File.WriteAllText(htmlPath, htmlContent);

            // Configure sandbox to allow only images
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Images;

            // Load the HTML document with the sandbox configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Verify image element is accessible
                Aspose.Html.Dom.Element imgElement = document.GetElementById("testImg");
                string imgSrc = imgElement != null ? imgElement.GetAttribute("src") : "Image not loaded";
                Console.WriteLine("Image src: " + imgSrc);

                // Verify script element is blocked (should be null or not loaded)
                Aspose.Html.Dom.Element scriptElement = document.GetElementById("testScript");
                string scriptInfo = scriptElement != null ? "Script element present" : "Script element blocked";
                Console.WriteLine("Script verification: " + scriptInfo);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}