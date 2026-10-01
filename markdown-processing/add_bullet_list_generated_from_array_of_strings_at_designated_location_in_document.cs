// Add a bullet list generated from an array of strings at a designated location in the document.

using System;
using System.IO;

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
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();
            Aspose.Html.Dom.Element body = document.Body;

            // Add a heading
            Aspose.Html.HTMLHeadingElement h1 = (Aspose.Html.HTMLHeadingElement)document.CreateElement("h1");
            h1.AppendChild(document.CreateTextNode("Sample Document"));
            body.AppendChild(h1);

            // Add a paragraph (the location before which the list will be inserted)
            Aspose.Html.HTMLParagraphElement paragraph = (Aspose.Html.HTMLParagraphElement)document.CreateElement("p");
            paragraph.AppendChild(document.CreateTextNode("This is a paragraph before the list."));
            body.AppendChild(paragraph);

            // Create an unordered list
            Aspose.Html.HTMLElement ul = (Aspose.Html.HTMLElement)document.CreateElement("ul");

            // Array of strings to be turned into list items
            string[] items = new string[] { "Item 1", "Item 2", "Item 3" };
            for (int i = 0; i < items.Length; i++)
            {
                Aspose.Html.HTMLElement li = (Aspose.Html.HTMLElement)document.CreateElement("li");
                li.AppendChild(document.CreateTextNode(items[i]));
                ul.AppendChild(li);
            }

            // Insert the list before the paragraph (designated location)
            body.InsertBefore(ul, paragraph);

            // Save the document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}