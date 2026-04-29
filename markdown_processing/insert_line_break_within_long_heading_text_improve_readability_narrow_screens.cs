// Insert a line break within a long heading text to improve readability on narrow screens.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            // Create a new empty HTML document
            HTMLDocument doc = new HTMLDocument();

            // Get the body element
            HTMLElement body = doc.Body;

            // Create a heading element (h1)
            HTMLHeadingElement h1 = (HTMLHeadingElement)doc.CreateElement("h1");

            // First part of the heading text
            Aspose.Html.Dom.Text txtPart1 = doc.CreateTextNode("This is a very long heading");
            h1.AppendChild(txtPart1);

            // Insert a line break (<br>) inside the heading
            HTMLElement br = (HTMLElement)doc.CreateElement("br");
            h1.AppendChild(br);

            // Second part of the heading text
            Aspose.Html.Dom.Text txtPart2 = doc.CreateTextNode("that needs a line break");
            h1.AppendChild(txtPart2);

            // Append the heading to the body
            body.AppendChild(h1);

            // Save the document to a file
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}