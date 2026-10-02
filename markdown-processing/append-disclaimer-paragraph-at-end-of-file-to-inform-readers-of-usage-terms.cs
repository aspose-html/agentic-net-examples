// Append a disclaimer paragraph at the end of the file to inform readers of usage terms.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new empty HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Get the body element of the document
            Aspose.Html.HTMLElement body = document.Body;

            // Create a <p> element
            Aspose.Html.HTMLParagraphElement paragraph = (Aspose.Html.HTMLParagraphElement)document.CreateElement("p");
            paragraph.SetAttribute("style", "color:blue;");

            // Create a text node and append it to the paragraph
            Aspose.Html.Dom.Text textNode = document.CreateTextNode("Hello, Aspose.HTML!");
            paragraph.AppendChild(textNode);

            // Append the paragraph to the body
            body.AppendChild(paragraph);

            // Save the document to a file
            string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);

            Console.WriteLine("Document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}

// Disclaimer: This example code is provided for demonstration purposes only. Use it in accordance with the Aspose.HTML licensing terms and any applicable laws.