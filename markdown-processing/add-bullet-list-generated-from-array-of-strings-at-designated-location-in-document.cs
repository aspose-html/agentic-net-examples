// Add a bullet list generated from an array of strings at a designated location in the document.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create output directory
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output");
            System.IO.Directory.CreateDirectory(outputDir);
            string outputPath = System.IO.Path.Combine(outputDir, "result.html");

            // Initialize HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLElement body = document.Body;

            // Add a heading
            Aspose.Html.HTMLHeadingElement h1 = (Aspose.Html.HTMLHeadingElement)document.CreateElement("h1");
            h1.AppendChild(document.CreateTextNode("Sample Document"));
            body.AppendChild(h1);

            // Add a paragraph
            Aspose.Html.HTMLParagraphElement p = (Aspose.Html.HTMLParagraphElement)document.CreateElement("p");
            p.AppendChild(document.CreateTextNode("Below is a generated bullet list:"));
            body.AppendChild(p);

            // Array of items for the bullet list
            string[] items = new string[] { "First item", "Second item", "Third item" };

            // Create unordered list element
            Aspose.Html.HTMLElement ul = (Aspose.Html.HTMLElement)document.CreateElement("ul");

            // Populate list items
            for (int i = 0; i < items.Length; i++)
            {
                Aspose.Html.HTMLElement li = (Aspose.Html.HTMLElement)document.CreateElement("li");
                li.AppendChild(document.CreateTextNode(items[i]));
                ul.AppendChild(li);
            }

            // Insert the list at the beginning of the body
            Aspose.Html.Dom.Node firstChild = body.FirstChild;
            if (firstChild != null)
                body.InsertBefore(ul, firstChild);
            else
                body.AppendChild(ul);

            // Save the document
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}