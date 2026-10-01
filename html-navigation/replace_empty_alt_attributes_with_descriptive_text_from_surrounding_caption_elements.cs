// Replace empty alt attributes with descriptive text derived from surrounding caption elements.

using System;
using System.IO;

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
                string sampleHtml = "<!DOCTYPE html><html><body>" +
                                    "<figure><img src='image1.png' alt=''><figcaption>Sample Image 1</figcaption></figure>" +
                                    "<figure><img src='image2.png'><figcaption>Sample Image 2</figcaption></figure>" +
                                    "</body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            Aspose.Html.Collections.HTMLCollection figures = document.GetElementsByTagName("figure");
            foreach (Aspose.Html.Dom.Element figureNode in figures)
            {
                Aspose.Html.Collections.HTMLCollection captions = figureNode.GetElementsByTagName("figcaption");
                if (captions.Length > 0)
                {
                    Aspose.Html.HTMLElement captionElement = (Aspose.Html.HTMLElement)captions[0];
                    string captionText = captionElement.InnerHTML;

                    Aspose.Html.Collections.HTMLCollection imgs = figureNode.GetElementsByTagName("img");
                    foreach (Aspose.Html.Dom.Element imgNode in imgs)
                    {
                        Aspose.Html.HTMLImageElement img = imgNode as Aspose.Html.HTMLImageElement;
                        if (img != null)
                        {
                            string alt = img.GetAttribute("alt");
                            if (string.IsNullOrWhiteSpace(alt))
                            {
                                img.SetAttribute("alt", captionText);
                            }
                        }
                    }
                }
            }

            document.Save(outputPath);
            Console.WriteLine("Processing completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}