// Load an HTML file with LoadOptions that ignore script elements, then apply background color changes.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output file paths
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal HTML file with a script element if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Test</title><script>console.log('script');</script></head><body><p>Hello World</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Configure behavior using Configuration
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            // Optionally adjust security flags if needed, e.g., config.Security = Aspose.Html.Sandbox.None;

            // Load the HTML document with the specified configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(new Aspose.Html.Url(inputPath), config);

            // Access the body element and change its background color
            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body").First();
            body.Style.BackgroundColor = "lightblue";

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}