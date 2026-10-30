// Set sandbox flags to disable both scripts and images, load a complex page, and verify content.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with script, image, and a test element
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <title>Sample Page</title>
    <script type='text/javascript'>
        document.title = 'Modified Title';
    </script>
</head>
<body>
    <div id='test'>Hello, Aspose.HTML!</div>
    <img src='https://example.com/image.png' alt='Sample Image' />
</body>
</html>";
            // Write HTML to a temporary file
            string tempFile = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempFile, htmlContent);

            // Configure sandbox to disable scripts and images
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;
            config.Security |= Aspose.Html.Sandbox.Images;

            // Load the document with the sandbox configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile, config))
            {
                // Verify that the test element is present
                var testElement = document.GetElementById("test");
                string text = testElement != null ? testElement.TextContent : "Element not found";
                Console.WriteLine("Test element text: " + text);

                // Attempt to retrieve the script element (should be present but not executed)
                var scriptElements = document.GetElementsByTagName("script");
                Console.WriteLine("Number of script elements: " + scriptElements.Length);

                // Attempt to retrieve the image element (should be present but not loaded)
                var imgElements = document.GetElementsByTagName("img");
                Console.WriteLine("Number of image elements: " + imgElements.Length);
            }

            // Clean up temporary file
            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}