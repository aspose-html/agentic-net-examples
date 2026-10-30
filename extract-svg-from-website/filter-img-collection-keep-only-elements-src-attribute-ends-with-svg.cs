// Filter the <img> collection to keep only elements whose src attribute ends with ".svg".

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
            string htmlPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Test</title></head><body>" +
                                    "<img src=\"image1.svg\" />" +
                                    "<img src=\"photo.jpg\" />" +
                                    "<img src=\"vector.svg\" />" +
                                    "<img src=\"icon.png\" />" +
                                    "</body></html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Get all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Iterate backwards to safely remove non‑SVG images
            for (int i = images.Length - 1; i >= 0; i--)
            {
                Element img = images[i];
                string src = img.GetAttribute("src");
                if (src == null || !src.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                {
                    img.ParentNode.RemoveChild(img);
                }
            }

            // Save the modified document
            document.Save(outputPath);
            Console.WriteLine($"Filtered HTML saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}