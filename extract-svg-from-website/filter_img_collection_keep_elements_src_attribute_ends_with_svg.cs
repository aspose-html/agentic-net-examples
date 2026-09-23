// Filter the <img> collection to keep only elements whose src attribute ends with ".svg".

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string sampleHtml = "<html><body>" +
                                    "<img src='image1.svg'/>" +
                                    "<img src='photo.jpg'/>" +
                                    "<img src='vector.SVG'/>" +
                                    "</body></html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Get all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            // Iterate backwards to safely remove elements
            for (int i = images.Length - 1; i >= 0; i--)
            {
                Aspose.Html.Dom.Element imgElement = (Aspose.Html.Dom.Element)images[i];
                string src = imgElement.GetAttribute("src");
                if (src == null || !src.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                {
                    // Remove <img> elements whose src does not end with .svg
                    imgElement.ParentNode.RemoveChild(imgElement);
                }
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