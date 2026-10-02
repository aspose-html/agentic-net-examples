// Set character encoding to UTF‑8 for all generated HTML files to ensure compatibility.

using System;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"><title>Sample</title></head><body><p>Hello, world! Привет мир!</p></body></html>";

            // Create HTMLDocument from inline content with a dummy base URI
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Save the document; Aspose.HTML writes UTF-8 by default
                document.Save(outputPath);
            }

            Console.WriteLine("HTML file saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}