// Extract the value of the charset meta tag and ensure it matches the file encoding.

using System;
using System.IO;
using System.Text;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with a charset meta tag (intentionally mismatched)
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"windows-1252\"></head><body><p>Hello, World!</p></body></html>";

            // Encode the HTML content using UTF-8 (desired encoding)
            byte[] bytes = Encoding.UTF8.GetBytes(htmlContent);

            // Load the HTML document from the memory stream
            using (var inputStream = new MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, "about:blank"))
            {
                // Find all <meta> elements
                var metaElements = document.GetElementsByTagName("meta");

                // Ensure the charset attribute matches the actual encoding (UTF-8)
                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    string charset = meta.GetAttribute("charset");
                    if (!string.IsNullOrEmpty(charset) && !charset.Equals("utf-8", StringComparison.OrdinalIgnoreCase))
                    {
                        meta.SetAttribute("charset", "utf-8");
                    }
                }

                // Save the corrected HTML to a file
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine($"Document saved to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}