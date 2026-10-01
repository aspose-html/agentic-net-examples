// Find phone number patterns within text nodes and output them for contact information extraction.

using System;
using System.Text.RegularExpressions;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body>Contact: John Doe, Phone: +1 (555) 123-4567. Another: 555-987-6543.</body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, ""))
            {
                IXPathResult result = document.Evaluate("//text()", document, null, Aspose.Html.Dom.XPath.XPathResultType.Any, null);
                for (Node node; (node = result.IterateNext()) != null;)
                {
                    string text = node.TextContent;
                    Regex regex = new Regex(@"\+?\d[\d\-\s\(\)]{7,}\d");
                    foreach (Match match in regex.Matches(text))
                    {
                        Console.WriteLine("Phone number found: " + match.Value);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}