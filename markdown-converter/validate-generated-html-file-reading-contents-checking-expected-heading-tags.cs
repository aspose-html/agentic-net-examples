// Validate the generated HTML file by reading its contents and checking for expected heading tags.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Define file path
            string htmlPath = "sample.html";

            // Create sample HTML content with headings
            string htmlContent = @"<!DOCTYPE html>
<html>
<head><title>Test Document</title></head>
<body>
<h1>Main Heading</h1>
<h2>Sub Heading</h2>
<p>Some paragraph text.</p>
</body>
</html>";

            // Write the sample HTML to a file
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document using Aspose.Html (demonstration purpose)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Read raw file content for validation
            string fileText = File.ReadAllText(htmlPath);

            // Check for expected heading tags
            bool hasH1 = fileText.Contains("<h1>", StringComparison.OrdinalIgnoreCase) &&
                         fileText.Contains("</h1>", StringComparison.OrdinalIgnoreCase);
            bool hasH2 = fileText.Contains("<h2>", StringComparison.OrdinalIgnoreCase) &&
                         fileText.Contains("</h2>", StringComparison.OrdinalIgnoreCase);

            // Output validation results
            Console.WriteLine($"File '{htmlPath}' validation results:");
            Console.WriteLine($"- Contains <h1> tag: {(hasH1 ? "Yes" : "No")}");
            Console.WriteLine($"- Contains <h2> tag: {(hasH2 ? "Yes" : "No")}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}