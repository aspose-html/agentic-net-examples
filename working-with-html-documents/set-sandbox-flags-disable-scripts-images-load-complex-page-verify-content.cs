// Set sandbox flags to disable both scripts and images, load a complex page, and verify content.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a temporary HTML file with script and image elements
            string htmlPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sample.html");
            string htmlContent = "<!DOCTYPE html><html><head><script>console.log('test');</script></head><body><img src='https://example.com/image.png' /><p id='msg'>Hello, Aspose!</p></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            // Configure sandbox to disable scripts and images
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;
            config.Security |= Aspose.Html.Sandbox.Images;

            // Load the document with the sandbox configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, config))
            {
                var scriptElements = document.GetElementsByTagName("script");
                var imageElements = document.GetElementsByTagName("img");

                Console.WriteLine("Scripts count (expected 0): " + scriptElements.Length);
                Console.WriteLine("Images count (expected 0): " + imageElements.Length);

                Aspose.Html.Dom.Element paragraph = document.GetElementById("msg");
                string paragraphText = paragraph != null ? paragraph.TextContent : string.Empty;
                Console.WriteLine("Paragraph text: " + paragraphText);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}