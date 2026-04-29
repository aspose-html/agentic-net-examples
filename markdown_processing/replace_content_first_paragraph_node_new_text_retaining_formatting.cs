// Replace the content of the first paragraph node with new text while retaining its formatting.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            using (var document = new Aspose.Html.HTMLDocument())
            {
                // Access the body element
                var body = document.Body;

                // Create the first paragraph element
                var paragraph = (Aspose.Html.HTMLParagraphElement)document.CreateElement("p");

                // Add initial text to the paragraph
                var originalText = document.CreateTextNode("Original text");
                paragraph.AppendChild(originalText);

                // Append the paragraph to the body
                body.AppendChild(paragraph);

                // Replace the paragraph's content while retaining its formatting
                paragraph.InnerHTML = "New replaced text";

                // Save the modified document
                document.Save("output.html");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}