// Extract image dimensions from HTML attributes and store them alongside file metadata.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            var document = new HTMLDocument(htmlPath);

            var images = document.QuerySelectorAll("img");
            var metadata = new List<(string Src, float Width, float Height)>();

            foreach (Element element in images)
            {
                if (element is HTMLImageElement img)
                {
                    string src = img.Src ?? string.Empty;
                    float width = img.Width;
                    float height = img.Height;
                    metadata.Add((src, width, height));
                }
            }

            foreach (var data in metadata)
            {
                Console.WriteLine($"Image: {data.Src}, Width: {data.Width}, Height: {data.Height}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}