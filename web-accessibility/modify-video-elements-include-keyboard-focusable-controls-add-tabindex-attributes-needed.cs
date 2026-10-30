// Modify video elements to include keyboard‑focusable controls by adding tabindex attributes where needed.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body><video src='sample.mp4'></video></body></html>";
            string baseUri = "about:blank";
            string outputPath = "output.html";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri))
            {
                Aspose.Html.Collections.NodeList videos = document.QuerySelectorAll("video");
                for (int i = 0; i < videos.Length; i++)
                {
                    Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)videos[i];
                    string tabindex = element.GetAttribute("tabindex");
                    if (string.IsNullOrEmpty(tabindex))
                    {
                        element.SetAttribute("tabindex", "0");
                    }
                }

                document.Save(outputPath);
                System.Console.WriteLine($"Modified HTML saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}