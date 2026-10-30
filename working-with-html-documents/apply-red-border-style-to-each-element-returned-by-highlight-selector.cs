// Apply a red border style to each element returned by the highlight selector.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><div class='highlight'>Hello</div><p class='highlight'>World</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll(".highlight");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                element.Style.BorderStyle = "solid";
                element.Style.BorderColor = "red";
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}