// Use HtmlLoadOptions to specify the correct encoding when loading non-UTF-8 HTML pages.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file (non‑UTF‑8)
            string sourcePath = "input.html";
            // Path where the processed HTML will be saved
            string outputPath = "output.html";

            // Specify the encoding of the source file (e.g., Windows‑1252)
            string encodingName = "windows-1252";

            // Read the HTML content using the specified encoding
            string htmlContent = System.IO.File.ReadAllText(sourcePath, System.Text.Encoding.GetEncoding(encodingName));

            // Base URI for the document (directory of the source file)
            string baseUri = System.IO.Path.GetDirectoryName(System.IO.Path.GetFullPath(sourcePath));

            // Create an HTMLDocument from the content and base URI
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Save the document to the output path
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}