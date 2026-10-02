// Replace an existing img element’s src attribute with a new image URL programmatically.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><body><img src=\"old.png\" alt=\"sample\"/></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                for (int i = 0; i < images.Length; i++)
                {
                    Aspose.Html.Dom.Element imageElement = (Aspose.Html.Dom.Element)images[i];
                    imageElement.SetAttribute("src", "https://example.com/newimage.png");
                }
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}