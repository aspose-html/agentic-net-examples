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
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><script>console.log('test');</script><p>Hello World</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Configure the HTML parser to ignore script execution
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security = Aspose.Html.Sandbox.None;

            // Load the HTML document with the specified configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, config);

            // Retrieve the <body> element
            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body").First();

            // Change the background color of the body
            body.Style.BackgroundColor = "lightblue";

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}