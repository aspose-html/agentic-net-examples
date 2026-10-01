// Convert all relative image source URLs to absolute URLs based on the document’s base tag.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a sample HTML file with a base tag and relative image sources
            string sampleHtml = @"<!DOCTYPE html>
<html>
<head>
    <base href=""https://example.com/assets/"" />
</head>
<body>
    <img src=""images/pic1.jpg"" alt=""Pic1"" />
    <img src=""/images/pic2.jpg"" alt=""Pic2"" />
    <img src=""https://otherdomain.com/img/pic3.jpg"" alt=""Pic3"" />
</body>
</html>";
            File.WriteAllText(inputPath, sampleHtml);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all img elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            // Iterate over each img element and convert relative src to absolute URL
            for (int i = 0; i < images.Length; i++)
            {
                Aspose.Html.Dom.Element imageElement = (Aspose.Html.Dom.Element)images[i];
                string src = imageElement.GetAttribute("src");
                Aspose.Html.Url url = new Aspose.Html.Url(src, document.BaseURI);
                imageElement.SetAttribute("src", url.ToString());
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}