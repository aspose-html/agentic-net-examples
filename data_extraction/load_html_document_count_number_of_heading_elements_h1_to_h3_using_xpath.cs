// Load an HTML document and count the number of heading elements from h1 to h3 using XPath.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

namespace HeadingCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlPath = "input.html";
                HTMLDocument document = new HTMLDocument(htmlPath);
                IXPathResult result = document.Evaluate("//h1|//h2|//h3", document, null, XPathResultType.Any, null);
                int count = 0;
                Node node;
                while ((node = result.IterateNext()) != null)
                {
                    count++;
                }
                Console.WriteLine($"Number of headings (h1-h3): {count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}