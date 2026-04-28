// Detect and list all elements with tabindex attributes to evaluate keyboard navigation order.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

namespace TabIndexDetector
{
    class Program
    {
        static void Main()
        {
            try
            {
                string url = "https://example.com";
                using (HTMLDocument document = new HTMLDocument(url))
                {
                    HTMLCollection allElements = document.GetElementsByTagName("*");
                    for (int i = 0; i < allElements.Length; i++)
                    {
                        Element element = allElements[i];
                        if (element.HasAttribute("tabindex"))
                        {
                            string attr = element.GetAttribute("tabindex");
                            int tabIndex;
                            int.TryParse(attr, out tabIndex);
                            Console.WriteLine($"Tag: {element.TagName}, TabIndex: {tabIndex}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}