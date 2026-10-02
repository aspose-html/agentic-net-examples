// Use HtmlLoadOptions to specify the correct encoding when loading non-UTF-8 HTML pages.

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
            // Define file paths
            string sourcePath = "sample_nonutf8.html";
            string outputPath = "converted.html";

            // Create a sample HTML file encoded in Windows-1251
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"windows-1251\"><title>Пример</title></head><body><p>Тестовый текст.</p></body></html>";
            File.WriteAllText(sourcePath, htmlContent, Encoding.GetEncoding("windows-1251"));

            // Read the HTML content using the correct encoding
            string readContent = File.ReadAllText(sourcePath, Encoding.GetEncoding("windows-1251"));

            // Load the HTML document from the string (inline content) with a placeholder base URI
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(readContent, "about:blank");

            // Save the document (will be saved as UTF-8 by default)
            document.Save(outputPath);

            Console.WriteLine("HTML document loaded with specified encoding and saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}