// Configure the parser to ignore XML namespaces when navigating HTML documents containing mixed content.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML with namespaces (mixed content)
            string htmlContent = @"<html xmlns:svg='http://www.w3.org/2000/svg'><body><svg:svg><svg:rect width='100' height='100' /></svg:svg><div>Sample</div></body></html>";

            // Load HTML content. Aspose.HTML does not provide a setting to ignore XML namespaces,
            // so the parser will handle namespaces as per its default behavior.
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Example navigation: get all 'div' elements (namespace-agnostic)
            Aspose.Html.Collections.HTMLCollection elements = document.GetElementsByTagName("div");
            for (int i = 0; i < elements.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)elements[i];
                Console.WriteLine(element.TagName);
            }

            // Example navigation: get all 'svg' elements (with namespace prefix)
            Aspose.Html.Collections.HTMLCollection svgElements = document.GetElementsByTagName("svg:svg");
            for (int i = 0; i < svgElements.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)svgElements[i];
                Console.WriteLine(element.TagName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}