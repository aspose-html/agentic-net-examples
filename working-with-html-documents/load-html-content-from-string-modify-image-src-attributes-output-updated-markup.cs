// Load HTML content from a string, modify image src attributes, and output the updated markup.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Sample</h1><img src='old1.png'/><img src='old2.jpg'/></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var images = document.GetElementsByTagName("img");
            foreach (var element in images)
            {
                var img = element as Aspose.Html.HTMLElement;
                if (img != null)
                {
                    string oldSrc = img.GetAttribute("src");
                    string fileName = Path.GetFileName(oldSrc);
                    string newSrc = "https://example.com/" + fileName;
                    img.SetAttribute("src", newSrc);
                }
            }

            string outputPath = "updated.html";
            document.Save(outputPath);
            Console.WriteLine($"Updated HTML saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}