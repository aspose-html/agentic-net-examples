// Parse the <base> tag in the HTML document to correctly resolve relative SVG URLs.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with <base> tag and an SVG image referencing a relative URL
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <base href=""https://example.com/assets/"" />
</head>
<body>
    <svg xmlns=""http://www.w3.org/2000/svg"" width=""200"" height=""200"">
        <image href=""image.png"" width=""100"" height=""100"" />
    </svg>
</body>
</html>";

            // Load HTML document (inline content) with a dummy base URI
            var htmlDoc = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Retrieve the <base> element and its href attribute
            var baseElements = htmlDoc.GetElementsByTagName("base");
            string baseHref = "";
            if (baseElements.Length > 0)
            {
                var baseElem = (Aspose.Html.HTMLElement)baseElements[0];
                baseHref = baseElem.GetAttribute("href");
            }

            // Retrieve the <image> element inside the SVG and its href attribute
            var imageElements = htmlDoc.GetElementsByTagName("image");
            string relativeUrl = "";
            if (imageElements.Length > 0)
            {
                var imageElem = (Aspose.Html.HTMLElement)imageElements[0];
                relativeUrl = imageElem.GetAttribute("href");
            }

            // Resolve the relative URL against the base href
            string resolvedUrl = "";
            if (!string.IsNullOrEmpty(baseHref) && !string.IsNullOrEmpty(relativeUrl))
            {
                resolvedUrl = new Uri(new Uri(baseHref), relativeUrl).ToString();
            }

            // Output the resolved URL
            Console.WriteLine("Base href: " + baseHref);
            Console.WriteLine("Relative URL: " + relativeUrl);
            Console.WriteLine("Resolved URL: " + resolvedUrl);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}