// Unwrap images from surrounding figure tags while preserving their src attributes intact.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
<figure><img src='image1.png' alt='Image 1'></figure>
<p>Some text.</p>
<figure><img src='image2.jpg' alt='Image 2'></figure>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                HTMLCollection figures = document.GetElementsByTagName("figure");
                for (int i = figures.Length - 1; i >= 0; i--)
                {
                    Element figure = (Element)figures[i];
                    HTMLCollection imgs = figure.GetElementsByTagName("img");
                    if (imgs.Length > 0)
                    {
                        Element img = (Element)imgs[0];
                        Element imgClone = (Element)img.CloneNode(true);
                        figure.ParentNode.InsertBefore(imgClone, figure);
                    }
                    figure.ParentNode.RemoveChild(figure);
                }

                document.Save(outputPath);
            }

            Console.WriteLine("Processing completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}