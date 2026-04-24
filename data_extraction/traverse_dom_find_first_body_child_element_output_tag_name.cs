// Traverse the DOM to find the first child element of the body and output its tag name.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Load HTML document from a string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("<html><body><div>Content</div></body></html>");
            // Get the root <html> element
            Aspose.Html.Dom.Element html = document.DocumentElement;
            // Get the <body> element (last child of <html>)
            Aspose.Html.Dom.Element body = html.LastElementChild;
            // Get the first child element inside <body>
            Aspose.Html.Dom.Element first = body.FirstElementChild;
            // Retrieve its tag name
            string tagFirst = first?.TagName ?? "None";
            // Output the tag name
            Console.WriteLine(tagFirst);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}