// Preserve existing alt attributes unchanged during the alt text addition process.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><img src='image1.png'><img src='image2.png' alt='Existing alt'></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
            foreach (Aspose.Html.Dom.Element node in images)
            {
                Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    string alt = img.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        string autoAlt = "Image";
                        img.SetAttribute("alt", autoAlt);
                    }
                }
            }
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Processed HTML saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}