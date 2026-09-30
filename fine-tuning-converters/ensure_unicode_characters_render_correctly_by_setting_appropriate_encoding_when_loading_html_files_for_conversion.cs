// Ensure Unicode characters render correctly by setting appropriate encoding when loading HTML files for conversion.

using System;
using System.IO;
using System.Text;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.html";
            string outputPath = "output.pdf";

            // Create a sample HTML file with Unicode characters if it does not exist
            if (!File.Exists(sourcePath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"></head><body>Привет мир! こんにちは世界! 🌍</body></html>";
                File.WriteAllText(sourcePath, sampleHtml, Encoding.UTF8);
            }

            // Read HTML content using the appropriate encoding
            string htmlContent = File.ReadAllText(sourcePath, Encoding.GetEncoding("utf-8"));

            // Load the HTML document with base URI
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, sourcePath);

            // Save the document (PDF format inferred from extension)
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}