// Modify video elements to include keyboard‑focusable controls by adding tabindex attributes where needed.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            var videoElements = document.QuerySelectorAll("video");
            for (int i = 0; i < videoElements.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)videoElements[i];
                element.SetAttribute("tabindex", "0");
            }

            document.Save(outputPath);
            Console.WriteLine("Video elements have been updated with tabindex attributes.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}