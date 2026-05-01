// Add the generated alt attribute to each identified <img> element.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            HTMLDocument document = new HTMLDocument(inputPath);
            HTMLCollection images = document.GetElementsByTagName("img");
            foreach (Element node in images)
            {
                HTMLImageElement img = node as HTMLImageElement;
                if (img != null)
                {
                    string alt = img.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        string autoAlt = "Generated Alt";
                        img.SetAttribute("alt", autoAlt);
                    }
                }
            }
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}