// Add a missing charset meta tag based on detected file encoding to improve compatibility.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string sourcePath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Test</title></head><body><p>Hello World</p></body></html>";
                File.WriteAllText(sourcePath, sampleHtml, Encoding.UTF8);
            }

            // Detect encoding (example: Windows-1252)
            string encodingName = "windows-1252";
            Encoding encoding = Encoding.GetEncoding(encodingName);

            // Read HTML content using the detected encoding
            string htmlContent = File.ReadAllText(sourcePath, encoding);

            // Load HTML into Aspose.HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");

            // Create <meta charset="..."> element
            Aspose.Html.HTMLElement meta = (Aspose.Html.HTMLElement)document.CreateElement("meta");
            meta.SetAttribute("charset", encoding.WebName);

            // Append meta element to <head>
            Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head")[0];
            head.AppendChild(meta);

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine($"Document saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}