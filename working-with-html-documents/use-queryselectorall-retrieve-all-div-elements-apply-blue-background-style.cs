// Use QuerySelectorAll to retrieve all <div> elements and apply a blue background style.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><title>Test</title></head><body><div>First</div><div>Second</div></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("div");
            for (int i = 0; i < elements.Length; i++)
            {
                var element = elements[i] as Aspose.Html.HTMLElement;
                if (element != null)
                {
                    element.Style.BackgroundColor = "blue";
                }
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