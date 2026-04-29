// Modify video elements to include keyboard‑focusable controls by adding tabindex attributes where needed.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

namespace VideoTabIndex
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";

                HTMLDocument document = new HTMLDocument(inputPath);
                var videos = document.QuerySelectorAll("video");
                for (int i = 0; i < videos.Length; i++)
                {
                    var element = (Element)videos[i];
                    if (string.IsNullOrEmpty(element.GetAttribute("tabindex")))
                    {
                        element.SetAttribute("tabindex", "0");
                    }
                }
                document.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}