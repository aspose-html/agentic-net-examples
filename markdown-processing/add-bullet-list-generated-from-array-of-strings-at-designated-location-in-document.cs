// Add a bullet list generated from an array of strings at a designated location in the document.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory and file path
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "result.html");

            // Create a new HTML document
            HTMLDocument document = new HTMLDocument();
            HTMLElement body = document.Body;

            // Add a heading
            HTMLHeadingElement h1 = (HTMLHeadingElement)document.CreateElement("h1");
            h1.AppendChild(document.CreateTextNode("Sample Document"));
            body.AppendChild(h1);

            // Add a paragraph
            HTMLParagraphElement paragraph = (HTMLParagraphElement)document.CreateElement("p");
            paragraph.AppendChild(document.CreateTextNode("Below is a list of items:"));
            body.AppendChild(paragraph);

            // Array of strings to be turned into a bullet list
            string[] items = new string[] { "Item 1", "Item 2", "Item 3" };

            // Create the unordered list element
            HTMLElement ul = (HTMLElement)document.CreateElement("ul");

            // Populate the list with <li> elements
            for (int i = 0; i < items.Length; i++)
            {
                HTMLElement li = (HTMLElement)document.CreateElement("li");
                li.AppendChild(document.CreateTextNode(items[i]));
                ul.AppendChild(li);
            }

            // Append the list to the body (after the paragraph)
            body.AppendChild(ul);

            // Save the document to the specified path
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}