// Implement lazy loading for large images by inserting placeholder syntax before actual image references.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = @"
                <html>
                    <head><title>Sample</title></head>
                    <body>
                        <p>First paragraph.</p>
                        <img src=""large-image1.jpg"" alt=""Image 1"" />
                        <p>Second paragraph.</p>
                        <img src=""large-image2.png"" alt=""Image 2"" />
                    </body>
                </html>";

            // Load HTML document with a base URI
            HTMLDocument document = new HTMLDocument(htmlContent, ".");

            // Get all img elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Replace each image source with a placeholder and store original src
            for (int i = 0; i < images.Length; i++)
            {
                Element imgElement = (Element)images[i];
                string originalSrc = imgElement.GetAttribute("src");
                if (!string.IsNullOrEmpty(originalSrc))
                {
                    imgElement.SetAttribute("data-original-src", originalSrc);
                    imgElement.SetAttribute("src", "placeholder.png");
                }
            }

            // Retrieve the modified HTML
            string modifiedHtml = document.DocumentElement.OuterHTML;

            // Save the result to a file
            string outputPath = Path.Combine(Environment.CurrentDirectory, "modified.html");
            File.WriteAllText(outputPath, modifiedHtml);
            Console.WriteLine($"Modified HTML saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}