// Find phone number patterns within text nodes and output them for contact information extraction.

using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><p>Contact us at 123-456-7890 or (555) 123 4567.</p><div>Another number: 987.654.3210</div></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, "about:blank");

            var result = document.Evaluate("//text()", document, null, Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            var phoneRegex = new Regex(@"\b\d{3}[-.\s]?\d{3}[-.\s]?\d{4}\b");

            bool anyFound = false;
            for (Aspose.Html.Dom.Node node; (node = result.IterateNext()) != null;)
            {
                string text = node.TextContent;
                var matches = phoneRegex.Matches(text);
                foreach (Match match in matches)
                {
                    Console.WriteLine($"Found phone number: {match.Value}");
                    anyFound = true;
                }
            }

            if (!anyFound)
            {
                Console.WriteLine("No phone numbers found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}