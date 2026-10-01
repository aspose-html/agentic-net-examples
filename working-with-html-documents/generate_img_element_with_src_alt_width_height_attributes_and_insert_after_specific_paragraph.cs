// Generate an img element with src, alt, width, and height attributes, and insert after a specific paragraph.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file as input
            string inputPath = "sample.html";
            string htmlContent = "<html><head><title>Sample</title></head><body><p>First paragraph.</p><p>Second paragraph.</p></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all paragraph elements
            Aspose.Html.Collections.HTMLCollection paragraphs = document.GetElementsByTagName("p");

            if (paragraphs.Length >= 2)
            {
                // Create an <img> element and set its attributes
                Aspose.Html.Dom.Element img = document.CreateElement("img");
                img.SetAttribute("src", "https://docs.aspose.com/html/images/aspose-html-for-net.png");
                img.SetAttribute("alt", "Aspose.HTML for .NET Product Logo");
                img.SetAttribute("width", "128");
                img.SetAttribute("height", "128");

                // Insert the image after the second paragraph
                Aspose.Html.Dom.Element secondParagraph = (Aspose.Html.Dom.Element)paragraphs[1];
                secondParagraph.ParentNode.InsertBefore(img, secondParagraph.NextSibling);
            }

            // Ensure every image has an alt attribute
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
            foreach (Aspose.Html.Dom.Element node in images)
            {
                Aspose.Html.HTMLImageElement imgElement = node as Aspose.Html.HTMLImageElement;
                if (imgElement != null)
                {
                    string alt = imgElement.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        imgElement.SetAttribute("alt", "Auto-generated alt text");
                    }
                }
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}