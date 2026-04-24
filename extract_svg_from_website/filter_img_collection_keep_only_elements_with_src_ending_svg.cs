// Filter the <img> collection to keep only elements whose src attribute ends with ".svg".

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.html";

            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                var images = document.Images;
                var toRemove = new System.Collections.Generic.List<Element>();

                foreach (Element img in images)
                {
                    string src = img.GetAttribute("src");
                    if (src == null || !src.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                    {
                        toRemove.Add(img);
                    }
                }

                foreach (Element img in toRemove)
                {
                    img.ParentNode.RemoveChild(img);
                }

                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}