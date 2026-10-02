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
            string html = "<html><body><p>Contact us at +1 (555) 123-4567 or 555-987-6543.</p><div>Another number: 123.456.7890</div></body></html>";

            using (HTMLDocument document = new HTMLDocument(html, "about:blank"))
            {
                IXPathResult result = document.Evaluate("//text()", document, null, XPathResultType.Any, null);
                Regex phoneRegex = new Regex(@"\+?\d[\d\-\.\(\) ]{7,}\d");
                bool anyFound = false;

                for (Node node; (node = result.IterateNext()) != null;)
                {
                    string text = node.TextContent;
                    MatchCollection matches = phoneRegex.Matches(text);
                    foreach (Match match in matches)
                    {
                        Console.WriteLine("Phone number found: " + match.Value);
                        anyFound = true;
                    }
                }

                if (!anyFound)
                {
                    Console.WriteLine("No phone numbers found.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}