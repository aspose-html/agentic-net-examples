// Create a text node with Unicode characters, append to a div, and save the document as UTF-8 HTML.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string sourcePath = "sample.html";
            string outputPathModified = "modified.html";
            string outputPathText = "textadded.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><meta name=\"description\" content=\"old\"></head><body><h1>Hello</h1></body></html>";
                File.WriteAllText(sourcePath, sampleHtml, Encoding.UTF8);
            }

            // Read HTML content from the source file
            string htmlContent = File.ReadAllText(sourcePath, Encoding.UTF8);

            // Load the document from a memory stream
            byte[] bytes = Encoding.UTF8.GetBytes(htmlContent);
            using (var inputStream = new MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, ""))
            {
                // Find all <meta> elements and modify the description meta tag
                var metaElements = document.GetElementsByTagName("meta");
                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    if (meta.GetAttribute("name") == "description")
                    {
                        meta.SetAttribute("content", "new description");
                    }
                }

                // Save the modified document
                document.Save(outputPathModified);
            }

            // Create a new empty document and add a text node
            using (var document = new Aspose.Html.HTMLDocument())
            {
                Aspose.Html.Dom.Text text = document.CreateTextNode("Sample text added via Aspose.Html.");
                document.Body.AppendChild(text);
                document.Save(outputPathText);
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}