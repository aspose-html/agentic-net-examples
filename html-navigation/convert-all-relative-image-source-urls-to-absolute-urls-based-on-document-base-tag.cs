// Convert all relative image source URLs to absolute URLs based on the document’s base tag.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with a base tag and relative image sources
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <base href='https://example.com/assets/' />
</head>
<body>
    <h1>Sample Page</h1>
    <img src='images/pic1.jpg' alt='Picture 1' />
    <img src='https://external.com/img.png' alt='External Image' />
    <img src='data:image/png;base64,iVBORw0KGgoAAAANSUhEUg...' alt='Embedded Image' />
</body>
</html>";

            // Load the document (inline content) with a placeholder base URI
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            // Iterate through the collection
            foreach (Aspose.Html.Dom.Element imageElement in images)
            {
                string src = imageElement.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                    continue;

                // Skip already absolute URLs and data URIs
                if (src.StartsWith("http", StringComparison.OrdinalIgnoreCase) ||
                    src.StartsWith("data:", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // Resolve relative URL against the document's base URI
                Aspose.Html.Url resolvedUrl = new Aspose.Html.Url(src, document.BaseURI);
                imageElement.SetAttribute("src", resolvedUrl.ToString());
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}