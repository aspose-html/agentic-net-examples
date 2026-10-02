// Apply a red border style to each element returned by the highlight selector.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p class='highlight'>First paragraph.</p><div class='highlight'>Highlighted div.</div><span>Normal span.</span></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll(".highlight");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                element.Style.BorderStyle = "solid";
                element.Style.BorderColor = "red";
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            System.Console.WriteLine("Document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}