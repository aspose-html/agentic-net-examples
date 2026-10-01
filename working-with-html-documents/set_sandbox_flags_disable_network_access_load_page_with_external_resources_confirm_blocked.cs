// Set sandbox flags to disable network access, load a page with external resources, and confirm they are blocked.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a simple HTML file that references external resources
            string htmlPath = "sample.html";
            string htmlContent = @"<!DOCTYPE html>
<html>
<head><title>Sandbox Test</title></head>
<body>
    <img id='testImg' src='https://example.com/image.png' />
    <script src='https://example.com/script.js'></script>
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Configure sandbox to block scripts and images (network resources)
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;
            configuration.Security |= Aspose.Html.Sandbox.Images;

            // Load the HTML document with the sandbox configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Attempt to access the image element
                var imgElement = document.GetElementById("testImg");
                string src = imgElement != null ? imgElement.GetAttribute("src") : null;
                Console.WriteLine("Image src attribute: " + src);

                // Indicate that network access has been disabled by the sandbox
                Console.WriteLine("Sandbox configured to block scripts and images (network access).");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}