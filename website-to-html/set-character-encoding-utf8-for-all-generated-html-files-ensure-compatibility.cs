// Set character encoding to UTF‑8 for all generated HTML files to ensure compatibility.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.html";
            string outputPath = "output.html";

            // Create sample HTML content with UTF-8 meta tag
            string sampleHtml = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>Sample</title></head><body><p>Hello, world!</p></body></html>";

            // Write the sample HTML to a file using UTF-8 encoding
            System.IO.File.WriteAllText(sourcePath, sampleHtml, System.Text.Encoding.UTF8);

            // Read the HTML content explicitly with UTF-8 encoding
            string htmlContent = System.IO.File.ReadAllText(sourcePath, System.Text.Encoding.GetEncoding("utf-8"));

            // Load the HTML content into an HTMLDocument (base URI placeholder)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Save the document; Aspose.Html saves HTML using UTF-8 by default
                document.Save(outputPath);
            }

            System.Console.WriteLine("HTML file saved with UTF-8 encoding at: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}