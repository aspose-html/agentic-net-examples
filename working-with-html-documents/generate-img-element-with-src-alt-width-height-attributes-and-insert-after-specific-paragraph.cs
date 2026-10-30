// Generate an img element with src, alt, width, and height attributes, and insert after a specific paragraph.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content with two paragraphs
            string htmlContent = "<html><body><p>First paragraph.</p><p>Second paragraph.</p></body></html>";

            // Load the HTML document from the inline content
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Get all paragraph elements
            HTMLCollection paragraphs = document.GetElementsByTagName("p");

            // Ensure there is at least one paragraph to insert after
            if (paragraphs.Length >= 1)
            {
                // Create the <img> element
                Element img = document.CreateElement("img");
                img.SetAttribute("src", "https://example.com/image.png");
                img.SetAttribute("alt", "Example Image");
                img.SetAttribute("width", "200");
                img.SetAttribute("height", "100");

                // Insert the image after the first paragraph
                Element targetParagraph = paragraphs[0];
                targetParagraph.ParentNode.InsertBefore(img, targetParagraph.NextSibling);
            }

            // Save the modified document
            string outputPath = "output.html";
            HTMLSaveOptions saveOptions = new HTMLSaveOptions();
            document.Save(outputPath, saveOptions);

            Console.WriteLine("HTML document saved to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}