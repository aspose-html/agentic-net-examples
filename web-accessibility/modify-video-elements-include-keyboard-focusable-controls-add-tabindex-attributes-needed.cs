// Modify video elements to include keyboard‑focusable controls by adding tabindex attributes where needed.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><video src='sample.mp4'></video><video src='sample2.mp4' tabindex='1'></video></body></html>";
            string baseUri = "about:blank";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri))
            {
                var elements = document.QuerySelectorAll("video");
                for (int i = 0; i < elements.Length; i++)
                {
                    Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)elements[i];
                    string tabindex = element.GetAttribute("tabindex");
                    if (string.IsNullOrEmpty(tabindex))
                    {
                        element.SetAttribute("tabindex", "0");
                    }
                }

                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine($"Modified HTML saved to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}