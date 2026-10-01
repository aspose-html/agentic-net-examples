// Add a custom data‑attribute to all heading elements for JavaScript interaction later.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document
            HTMLDocument doc = new HTMLDocument();

            // Get the body element
            HTMLElement body = doc.Body;

            // Create first heading (h1) with custom data-attribute
            HTMLElement h1 = (HTMLElement)doc.CreateElement("h1");
            h1.SetAttribute("data-custom", "heading1");
            h1.AppendChild(doc.CreateTextNode("Sample Heading 1"));
            body.AppendChild(h1);

            // Create second heading (h2) with custom data-attribute
            HTMLElement h2 = (HTMLElement)doc.CreateElement("h2");
            h2.SetAttribute("data-custom", "heading2");
            h2.AppendChild(doc.CreateTextNode("Sample Heading 2"));
            body.AppendChild(h2);

            // Save the document to a file
            string outputPath = "output.html";
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}