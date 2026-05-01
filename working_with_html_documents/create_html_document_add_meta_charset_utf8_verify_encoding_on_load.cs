// Create an HTML document, add a meta charset UTF‑8, and verify correct encoding on load.

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
            // Create HTML content with UTF‑8 meta tag
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>Test</title></head><body><p>Hello World</p></body></html>";
            string baseUri = "file:///";
            string outputPath = "document.html";

            // Create HTMLDocument from string and save it
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
            document.Save(outputPath);

            // Load the saved document using explicit UTF‑8 encoding
            string sourcePath = outputPath;
            string loadedHtml = File.ReadAllText(sourcePath, Encoding.GetEncoding("utf-8"));
            string loadOutputPath = "loaded.html";
            Aspose.Html.HTMLDocument loadedDocument = new Aspose.Html.HTMLDocument(loadedHtml, baseUri);
            loadedDocument.Save(loadOutputPath);

            // Verify the document's charset
            Console.WriteLine("Document charset: " + loadedDocument.Charset);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}