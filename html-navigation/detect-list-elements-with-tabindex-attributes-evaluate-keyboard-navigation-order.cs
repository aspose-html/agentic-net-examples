// Detect and list all elements with tabindex attributes to evaluate keyboard navigation order.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string html = @"<html><body>" +
                          "<a href='#' tabindex='3'>Link 1</a>" +
                          "<button tabindex='1'>Button</button>" +
                          "<div>Div without tabindex</div>" +
                          "<input type='text' tabindex='2' />" +
                          "</body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("[tabindex]");

                var results = new List<string>();

                for (int i = 0; i < elements.Length; i++)
                {
                    Aspose.Html.HTMLElement element = elements[i] as Aspose.Html.HTMLElement;
                    if (element != null)
                    {
                        string tabindex = element.GetAttribute("tabindex");
                        string tag = element.TagName;
                        string text = element.TextContent != null ? element.TextContent.Trim() : string.Empty;
                        results.Add($"{tag} (tabindex={tabindex}) - \"{text}\"");
                    }
                }

                Console.WriteLine("Elements with tabindex attribute:");
                foreach (var line in results)
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}