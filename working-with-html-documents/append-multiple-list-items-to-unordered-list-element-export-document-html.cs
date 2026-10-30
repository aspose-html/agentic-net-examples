// Append multiple list items to an unordered list element, then export the document as HTML.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();

            // Get the body element
            Aspose.Html.HTMLElement body = doc.Body;

            // Create an unordered list element
            Aspose.Html.HTMLElement ul = (Aspose.Html.HTMLElement)doc.CreateElement("ul");

            // List items to add
            string[] items = { "First item", "Second item", "Third item" };

            // Append list items to the unordered list
            foreach (string itemText in items)
            {
                Aspose.Html.HTMLElement li = (Aspose.Html.HTMLElement)doc.CreateElement("li");
                Aspose.Html.Dom.Text textNode = doc.CreateTextNode(itemText);
                li.AppendChild(textNode);
                ul.AppendChild(li);
            }

            // Insert the list at the beginning of the body
            Aspose.Html.Dom.Node firstChild = body.FirstChild;
            if (firstChild != null)
                body.InsertBefore(ul, firstChild);
            else
                body.AppendChild(ul);

            // Save the document as HTML
            string outputPath = "output.html";
            doc.Save(outputPath);

            Console.WriteLine($"HTML document saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}