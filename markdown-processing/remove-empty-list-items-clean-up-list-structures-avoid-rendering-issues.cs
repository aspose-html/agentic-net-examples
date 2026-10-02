// Remove all empty list items to clean up list structures and avoid rendering issues.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head><title>Sample List</title></head>
<body>
<ul>
<li>Item 1</li>
<li></li>
<li>   </li>
<li>Item 2</li>
</ul>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Collections.HTMLCollection listItems = document.GetElementsByTagName("li");

                foreach (Aspose.Html.Dom.Element li in listItems.ToList())
                {
                    Aspose.Html.HTMLElement htmlElement = li as Aspose.Html.HTMLElement;
                    if (htmlElement != null && string.IsNullOrWhiteSpace(htmlElement.InnerHTML))
                    {
                        li.ParentNode.RemoveChild(li);
                    }
                }

                document.Save(outputPath);
            }

            Console.WriteLine($"Processing completed. Cleaned HTML saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}