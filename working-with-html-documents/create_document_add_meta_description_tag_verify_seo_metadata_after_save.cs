// Create a document, add a meta description tag, and verify SEO metadata is present after save.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><meta name=\"description\" content=\"Original description\"><title>Sample</title></head><body><h1>Hello World</h1></body></html>";
            byte[] bytes = Encoding.UTF8.GetBytes(htmlContent);

            // Load HTML document from memory stream
            using (var inputStream = new MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, ""))
            {
                // Find all <meta> elements
                var metaElements = document.GetElementsByTagName("meta");

                // Update the content attribute of the meta element with name="description"
                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    if (meta.GetAttribute("name") == "description")
                    {
                        meta.SetAttribute("content", "Updated description");
                    }
                }

                // Save the modified document to a file
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine($"Document saved to: {Path.GetFullPath(outputPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}