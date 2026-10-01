// Set character encoding to ISO-8859-1, load an HTML string, and save the document as HTML.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello Aspose.HTML</h1></body></html>";
                File.WriteAllText(sourcePath, sampleHtml, Encoding.UTF8);
            }

            // Read the HTML content using the specified encoding
            string htmlContent = File.ReadAllText(sourcePath, Encoding.GetEncoding("utf-8"));

            // Load the HTML content into an Aspose.HTML document
            var document = new Aspose.Html.HTMLDocument(htmlContent, "");

            // Save the document to the output path
            document.Save(outputPath);

            Console.WriteLine($"HTML document saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}