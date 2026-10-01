// Create an HTML document, add a data‑attribute to a div, and verify attribute persists after save.

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            // Create a new empty HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Get the body element
            Aspose.Html.HTMLElement body = document.Body;

            // Create a <div> element
            Aspose.Html.Dom.Element div = document.CreateElement("div");

            // Set a data-attribute on the div
            div.SetAttribute("data-test", "123");

            // Append the div to the body
            body.AppendChild(div);

            // Save the document to a file
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}