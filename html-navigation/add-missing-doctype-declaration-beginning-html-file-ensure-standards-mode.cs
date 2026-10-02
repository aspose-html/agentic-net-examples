// Add a missing DOCTYPE declaration at the beginning of the HTML file to ensure standards mode.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><head><title>Sample</title></head><body><p>Hello, World!</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml, Encoding.UTF8);
            }

            // Read the HTML content
            string html = File.ReadAllText(inputPath, Encoding.UTF8);

            // Add DOCTYPE if missing
            if (!html.TrimStart().StartsWith("<!DOCTYPE", StringComparison.OrdinalIgnoreCase))
            {
                html = "<!DOCTYPE html>\n" + html;
            }

            // Load the HTML into Aspose.HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");

            // Save the updated document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}