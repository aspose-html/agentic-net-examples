// Apply a custom NodeFilter that excludes nodes with display:none style during DOM traversal.

using System;

namespace AsposeHtmlNodeFilterExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string html = "<html><body>" +
                              "<div id='visible'>Visible content</div>" +
                              "<p style='display:none'>Hidden content</p>" +
                              "<span style='color:red;'>Red text</span>" +
                              "</body></html>";

                var document = new Aspose.Html.HTMLDocument(html, "about:blank");

                var allElements = document.GetElementsByTagName("*");
                foreach (Aspose.Html.Dom.Element element in allElements)
                {
                    var style = element.GetAttribute("style");
                    if (!string.IsNullOrEmpty(style) && style.Contains("display:none"))
                    {
                        continue; // skip hidden elements
                    }

                    Console.WriteLine($"Element: <{element.TagName}>");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    // Helper class retained for potential future use; does not depend on unavailable APIs.
    class OnlyVisibleFilter
    {
        public static bool IsVisible(Aspose.Html.Dom.Element element)
        {
            var style = element.GetAttribute("style");
            return string.IsNullOrEmpty(style) || !style.Contains("display:none");
        }
    }
}