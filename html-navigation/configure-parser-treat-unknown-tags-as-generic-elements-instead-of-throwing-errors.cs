// Configure the parser to treat unknown tags as generic elements instead of throwing errors.

using System;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Sample HTML containing an unknown/custom tag.
                string htmlContent = "<html><body><custom-tag>Hello</custom-tag></body></html>";

                // Load the HTML content. The parser treats unknown tags as generic elements by default.
                // Note: Aspose.Html.Configuration does not expose a setting to change unknown tag handling.
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

                // Retrieve all elements (including unknown tags) and print their tag names.
                Aspose.Html.Collections.HTMLCollection elements = document.GetElementsByTagName("*");
                for (int i = 0; i < elements.Length; i++)
                {
                    Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)elements[i];
                    Console.WriteLine(element.TagName);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
            }
        }
    }
}