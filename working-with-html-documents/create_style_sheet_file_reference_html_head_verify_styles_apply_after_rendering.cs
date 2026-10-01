// Create a style sheet file, reference it in the HTML head, and verify styles apply after rendering.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><head></head><body><p>Hello World</p></body></html>";

            // Create an HTML document from the string
            var document = new Aspose.Html.HTMLDocument(htmlContent);

            // Get the <body> element and remove any existing background-color style
            var body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body").First();
            body.Style.RemoveProperty("background-color");

            // Create a <style> element that sets a new background color
            var style = (Aspose.Html.HTMLStyleElement)document.CreateElement("style");
            style.TextContent = "body { background-color: rgb(229, 243, 253) }";

            // Append the style element to the <head>
            var head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Document saved to {Path.GetFullPath(outputPath)}");

            // Demonstrate using a custom configuration with a user style sheet
            using (var config = new Aspose.Html.Configuration())
            {
                var userAgentService = config.GetService<Aspose.Html.Services.IUserAgentService>();
                userAgentService.UserStyleSheet = "body { font-family: Arial, sans-serif; }";

                // Create a new document using the configuration
                var documentWithConfig = new Aspose.Html.HTMLDocument(htmlContent, config);
                string configOutputPath = "output_with_config.html";
                documentWithConfig.Save(configOutputPath);
                Console.WriteLine($"Document with custom config saved to {Path.GetFullPath(configOutputPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}