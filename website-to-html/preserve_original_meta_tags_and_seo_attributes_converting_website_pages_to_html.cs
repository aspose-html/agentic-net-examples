// Preserve original meta tags and SEO attributes when converting website pages to HTML.

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
            // Sample HTML content with meta tags
            string htmlContent = "<!DOCTYPE html><html><head><meta name=\"description\" content=\"Sample page\"><meta name=\"keywords\" content=\"aspnet,aspose\"><title>Sample</title></head><body><h1>Hello</h1></body></html>";
            byte[] bytes = Encoding.UTF8.GetBytes(htmlContent);

            // Load HTML from memory stream
            using (var inputStream = new MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, string.Empty))
            {
                // Locate all meta elements (preserve them)
                var metaElements = document.GetElementsByTagName("meta");
                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    // Example: re-assign existing attribute to ensure it stays unchanged
                    if (meta.GetAttribute("name") == "description")
                    {
                        meta.SetAttribute("content", meta.GetAttribute("content"));
                    }
                }

                // Save the document preserving original meta tags
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine($"HTML saved to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}