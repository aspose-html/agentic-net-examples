// Locate an element by ID with GetElementById and apply an inline border-color style.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><div id='target'>Hello World</div></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Dom.Element element = document.GetElementById("target");
            if (element is Aspose.Html.HTMLElement htmlElement)
            {
                htmlElement.Style.BorderStyle = "solid";
                htmlElement.Style.BorderColor = "red";
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