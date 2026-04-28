// Detect and extract all comment nodes that contain TODO markers for development tracking.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            HTMLDocument document = new HTMLDocument(htmlPath);
            string xpath = "//comment()[contains(., 'TODO')]";
            IXPathResult result = document.Evaluate(xpath, document, null, XPathResultType.Any, null);
            Node node;
            while ((node = result.IterateNext()) != null)
            {
                Comment comment = node as Comment;
                if (comment != null)
                {
                    Console.WriteLine(comment.Data);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}