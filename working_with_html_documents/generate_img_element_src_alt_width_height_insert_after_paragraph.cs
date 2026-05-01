// Generate an img element with src, alt, width, and height attributes, and insert after a specific paragraph.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

namespace InsertImageAfterParagraph
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output HTML file paths
                string inputPath = "input.html";
                string outputPath = "output.html";

                // Image attributes
                string imageSrc = "https://example.com/image.png";
                string imageAlt = "Example Image";
                string imageWidth = "200";
                string imageHeight = "100";

                // Load the existing HTML document
                HTMLDocument document = new HTMLDocument(inputPath);

                // Get all paragraph elements
                HTMLCollection paragraphs = document.GetElementsByTagName("p");

                // Ensure there are at least two paragraphs
                if (paragraphs.Length >= 2)
                {
                    // Create a new <img> element
                    Element img = document.CreateElement("img");

                    // Set image attributes
                    img.SetAttribute("src", imageSrc);
                    img.SetAttribute("alt", imageAlt);
                    img.SetAttribute("width", imageWidth);
                    img.SetAttribute("height", imageHeight);

                    // Reference the second paragraph (index 1)
                    Element secondParagraph = paragraphs[1];

                    // Insert the image after the second paragraph
                    secondParagraph.ParentNode.InsertBefore(img, secondParagraph.NextSibling);
                }

                // Save the modified document
                HTMLSaveOptions saveOptions = new HTMLSaveOptions();
                document.Save(outputPath, saveOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}