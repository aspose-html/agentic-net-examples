// Add a YAML front‑matter block at the top with custom metadata fields for the document.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new empty HTML document
            HTMLDocument document = new HTMLDocument();

            // Define YAML front‑matter block
            string yaml = "---\n" +
                          "title: Sample Document\n" +
                          "author: John Doe\n" +
                          "date: 2024-04-24\n" +
                          "---\n";

            // Create a text node containing the YAML and insert it before the <html> element
            var yamlNode = document.CreateTextNode(yaml);
            document.InsertBefore(yamlNode, document.DocumentElement);

            // Access the body element
            HTMLElement body = document.Body;

            // Create <h1> element with text
            HTMLHeadingElement h1 = (HTMLHeadingElement)document.CreateElement("h1");
            var texth1 = document.CreateTextNode("Create HTML file");
            h1.AppendChild(texth1);

            // Create <p> element with text
            HTMLParagraphElement p = (HTMLParagraphElement)document.CreateElement("p");
            var text = document.CreateTextNode("Learn how to create HTML file");
            p.AppendChild(text);

            // Append heading and paragraph to the body
            body.AppendChild(h1);
            body.AppendChild(p);

            // Save the document to a file
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}