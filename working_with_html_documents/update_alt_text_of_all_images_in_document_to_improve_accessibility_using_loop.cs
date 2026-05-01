// Update alt text of all images in the document to improve accessibility using a loop.

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
            string inputPath = "input.html";
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            foreach (Aspose.Html.Dom.Element node in images)
            {
                Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    string alt = img.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        string src = img.GetAttribute("src");
                        string fileName = Path.GetFileNameWithoutExtension(src ?? "image");
                        string autoAlt = $"Image of {fileName}";
                        img.SetAttribute("alt", autoAlt);
                    }
                }
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}