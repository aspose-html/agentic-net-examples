// Add a missing charset meta tag based on detected file encoding to improve compatibility.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string sourcePath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p></body></html>";
                File.WriteAllText(sourcePath, sampleHtml, Encoding.UTF8);
            }

            // Detect encoding (for this example we assume UTF-8)
            string encodingName = "utf-8";
            string htmlContent = File.ReadAllText(sourcePath, Encoding.GetEncoding(encodingName));

            // Add charset meta tag if missing
            if (!htmlContent.Contains("<meta charset=", StringComparison.OrdinalIgnoreCase))
            {
                if (htmlContent.Contains("<head>", StringComparison.OrdinalIgnoreCase))
                {
                    htmlContent = htmlContent.Replace("<head>", "<head><meta charset=\"utf-8\">", StringComparison.OrdinalIgnoreCase);
                }
                else if (htmlContent.Contains("<html>", StringComparison.OrdinalIgnoreCase))
                {
                    htmlContent = htmlContent.Replace("<html>", "<html><head><meta charset=\"utf-8\"></head>", StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    htmlContent = "<meta charset=\"utf-8\">" + htmlContent;
                }
            }

            // Load HTML content into Aspose.HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine($"HTML saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}