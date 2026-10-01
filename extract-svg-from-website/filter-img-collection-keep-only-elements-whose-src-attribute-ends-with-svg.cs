// Filter the <img> collection to keep only elements whose src attribute ends with ".svg".

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
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><body>" +
                                    "<img src=\"image1.svg\" />" +
                                    "<img src=\"photo.jpg\" />" +
                                    "<img src=\"vector.svg\" />" +
                                    "<img src=\"icon.png\" />" +
                                    "</body></html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            for (int i = images.Length - 1; i >= 0; i--)
            {
                Aspose.Html.Dom.Element img = images[i];
                string src = img.GetAttribute("src");
                if (src == null || !src.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                {
                    img.ParentNode.RemoveChild(img);
                }
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Filtered HTML saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}