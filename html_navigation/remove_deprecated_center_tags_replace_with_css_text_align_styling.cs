// Remove all deprecated <center> tags and replace them with CSS text‑align styling.

using System;
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

            HTMLDocument document = new HTMLDocument(inputPath);

            HTMLCollection centers = document.GetElementsByTagName("center");
            // Iterate in reverse to safely replace nodes while iterating
            for (int i = centers.Length - 1; i >= 0; i--)
            {
                Element center = (Element)centers[i];
                Element replacement = document.CreateElement("div");
                replacement.InnerHTML = center.InnerHTML;
                replacement.SetAttribute("style", "text-align:center;");
                Node parent = center.ParentNode;
                parent.ReplaceChild(replacement, center);
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}