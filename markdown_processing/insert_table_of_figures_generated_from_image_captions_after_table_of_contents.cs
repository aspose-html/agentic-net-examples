// Insert a table of figures generated from image captions and place it after the table of contents.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Load the existing HTML document
            HTMLDocument document = new HTMLDocument("input.html");

            // Locate the Table of Contents (assumed to be the first <h1> element)
            HTMLCollection headings = document.GetElementsByTagName("h1");
            if (headings.Length == 0)
                throw new InvalidOperationException("Table of Contents not found.");

            Element toc = headings[0];

            // Create a container for the Table of Figures
            Element figuresDiv = document.CreateElement("div");
            Element figuresHeader = document.CreateElement("h2");
            figuresHeader.SetAttribute("id", "table-of-figures");
            figuresHeader.SetAttribute("style", "font-weight:bold;");
            figuresHeader.AppendChild(document.CreateTextNode("Table of Figures"));
            figuresDiv.AppendChild(figuresHeader);

            // Create a list to hold figure entries
            Element list = document.CreateElement("ul");
            figuresDiv.AppendChild(list);

            // Iterate over all images and add entries based on their alt attribute
            HTMLCollection images = document.GetElementsByTagName("img");
            for (int i = 0; i < images.Length; i++)
            {
                Element img = images[i];
                string alt = img.GetAttribute("alt");
                if (string.IsNullOrWhiteSpace(alt))
                    alt = $"Figure {i + 1}";

                // Create list item
                Element listItem = document.CreateElement("li");
                // Optionally, create a link to the image (using its src)
                string src = img.GetAttribute("src");
                if (!string.IsNullOrWhiteSpace(src))
                {
                    Element link = document.CreateElement("a");
                    link.SetAttribute("href", src);
                    link.AppendChild(document.CreateTextNode(alt));
                    listItem.AppendChild(link);
                }
                else
                {
                    listItem.AppendChild(document.CreateTextNode(alt));
                }

                list.AppendChild(listItem);
            }

            // Insert the Table of Figures after the Table of Contents
            Node parent = toc.ParentNode;
            Node nextSibling = toc.NextSibling;
            parent.InsertBefore(figuresDiv, nextSibling);

            // Save the modified document
            document.Save("output.html", new HTMLSaveOptions());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}