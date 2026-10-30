// Use HtmlLoadOptions to specify the correct encoding when loading non-UTF-8 HTML pages.

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

            // Create a sample non‑UTF‑8 HTML file (Windows‑1251 encoding)
            string sampleContent = "<html><body><p>Привет мир</p></body></html>";
            File.WriteAllText(sourcePath, sampleContent, Encoding.GetEncoding("windows-1251"));

            // Read the HTML file with the correct encoding
            string htmlContent = File.ReadAllText(sourcePath, Encoding.GetEncoding("windows-1251"));

            // Load the document from the HTML string using a placeholder base URI
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Save the document (default UTF‑8 encoding)
            document.Save(outputPath);

            Console.WriteLine("Document loaded with specified encoding and saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}