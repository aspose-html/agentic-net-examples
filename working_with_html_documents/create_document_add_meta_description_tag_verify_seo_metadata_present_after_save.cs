// Create a document, add a meta description tag, and verify SEO metadata is present after save.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            // Create an empty HTML document
            using (HTMLDocument document = new HTMLDocument())
            {
                // Add a meta description tag to the head
                Element head = document.QuerySelector("head");
                if (head != null)
                {
                    Element meta = document.CreateElement("meta");
                    meta.SetAttribute("name", "description");
                    meta.SetAttribute("content", "Sample description for SEO.");
                    head.AppendChild(meta);
                }

                // Save the document
                document.Save(outputPath);
            }

            // Load the saved document and verify the meta description exists
            using (HTMLDocument loadedDoc = new HTMLDocument(outputPath))
            {
                Element metaDesc = loadedDoc.QuerySelector("meta[name='description']");
                if (metaDesc != null && !string.IsNullOrWhiteSpace(metaDesc.GetAttribute("content")))
                {
                    Console.WriteLine("Meta description tag is present and contains content.");
                }
                else
                {
                    Console.WriteLine("Meta description tag is missing or empty.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}