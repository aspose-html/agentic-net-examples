// Load an HTML file and extract image source attributes by selecting img tags with a CSS selector.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file with images if it does not exist
            string htmlFilePath = "sample.html";
            if (!File.Exists(htmlFilePath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <img src=""image1.png"" alt=""Image 1"" />
    <img src=""https://example.com/image2.jpg"" alt=""Image 2"" />
</body>
</html>";
                File.WriteAllText(htmlFilePath, sampleHtml);
            }

            // Load the HTML document from the file
            using (HTMLDocument document = new HTMLDocument(htmlFilePath))
            {
                // Get all <img> elements
                HTMLCollection images = document.GetElementsByTagName("img");

                // Iterate and print the src attribute of each image
                foreach (Element img in images)
                {
                    string src = img.GetAttribute("src");
                    Console.WriteLine(src);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}