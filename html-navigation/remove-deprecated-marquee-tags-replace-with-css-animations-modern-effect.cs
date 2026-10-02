// Remove all deprecated <marquee> tags and replace them with CSS animations for modern effect.

using System;
using System.IO;
using System.Linq;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing <marquee> tags
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <title>Marquee Replacement Example</title>
</head>
<body>
    <marquee>Scrolling Text 1</marquee>
    <p>Some other content.</p>
    <marquee>Scrolling Text 2</marquee>
</body>
</html>";

            // Load HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create CSS animation style
            Aspose.Html.Dom.Element styleElement = document.CreateElement("style");
            styleElement.TextContent = @"
.marquee-animation {
    display: inline-block;
    white-space: nowrap;
    overflow: hidden;
    animation: scroll-left 5s linear infinite;
}
@keyframes scroll-left {
    from { transform: translateX(100%); }
    to { transform: translateX(-100%); }
}";
            // Append style to <head>
            Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head").First();
            head.AppendChild(styleElement);

            // Find all <marquee> elements
            Aspose.Html.Collections.HTMLCollection marqueeElements = document.GetElementsByTagName("marquee");
            // Convert collection to array to avoid modification during iteration
            var marqueeArray = marqueeElements.Cast<Aspose.Html.Dom.Element>().ToArray();

            foreach (Aspose.Html.Dom.Element marquee in marqueeArray)
            {
                // Cast to HTMLElement to access TextContent
                Aspose.Html.HTMLElement marqueeHtml = (Aspose.Html.HTMLElement)marquee;
                string text = marqueeHtml.TextContent;

                // Create replacement <div> with animation class
                Aspose.Html.HTMLElement replacement = (Aspose.Html.HTMLElement)document.CreateElement("div");
                replacement.ClassName = "marquee-animation";
                replacement.TextContent = text;

                // Replace <marquee> with the new element
                marquee.ParentNode.ReplaceChild(replacement, marquee);
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Document saved to '{Path.GetFullPath(outputPath)}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}