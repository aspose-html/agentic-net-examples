// Configure sandbox to allow images, disable scripts, load a page, and verify only images appear.

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
            // Prepare HTML content with an image and a script
            string htmlContent = "<html><body><img src='https://example.com/image.png' /><script>alert('hi');</script></body></html>";
            string htmlPath = Path.Combine(Path.GetTempPath(), "test.html");
            File.WriteAllText(htmlPath, htmlContent);

            // Configure sandbox: disable scripts, allow images
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts; // block script execution

            // Load the HTML document with the sandbox configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Verify that images are present
                var images = document.GetElementsByTagName("img");
                Console.WriteLine($"Images count: {images.Length}");

                // Verify that scripts are not executed/loaded
                var scripts = document.GetElementsByTagName("script");
                Console.WriteLine($"Scripts count (should be 0): {scripts.Length}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}