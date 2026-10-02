// Extract image dimensions from HTML attributes and store them alongside file metadata.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string htmlPath = "sample.html";
            string outputCsvPath = "image_metadata.csv";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <img src=""image1.jpg"" width=""640"" height=""480"" alt=""Image 1"" />
    <img src=""image2.png"" width=""800"" height=""600"" alt=""Image 2"" />
</body>
</html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Query all img elements
            var imgNodeList = document.QuerySelectorAll("img");

            var records = new List<string>();
            records.Add("Src,Width,Height");

            for (int i = 0; i < imgNodeList.Length; i++)
            {
                var element = imgNodeList[i] as Aspose.Html.Dom.Element;
                if (element == null)
                    continue;

                var img = element as Aspose.Html.HTMLImageElement;
                if (img == null)
                    continue;

                string src = img.GetAttribute("src") ?? "";
                string widthAttr = img.GetAttribute("width") ?? "0";
                string heightAttr = img.GetAttribute("height") ?? "0";

                int width = 0;
                int height = 0;
                Int32.TryParse(widthAttr, out width);
                Int32.TryParse(heightAttr, out height);

                records.Add($"{src},{width},{height}");
            }

            // Write metadata to CSV file
            File.WriteAllLines(outputCsvPath, records);

            Console.WriteLine($"Image metadata extracted to '{outputCsvPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}