// Load HTML content from a string, modify image src attributes, and output the updated markup.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Inline HTML content
            string htmlContent = "<html><body><img src='old1.png'/><img src='old2.jpg'/></body></html>";

            // Load HTML from string using two-argument constructor (content, baseUri)
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Get all <img> elements
            HTMLCollection images = document.Images;

            // Modify each image's src attribute
            for (int i = 0; i < images.Length; i++)
            {
                Node node = images[i];
                if (node.NodeType == Node.ELEMENT_NODE)
                {
                    HTMLElement imgElement = (HTMLElement)node;
                    imgElement.SetAttribute("src", "new_image.png");
                }
            }

            // Save the updated markup to a file
            string outputPath = "updated.html";
            document.Save(outputPath);

            Console.WriteLine("Updated HTML saved to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}