// Detect and remove empty style tags that contain no CSS rules in the document.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><head><style>body {color:red;}</style><style></style></head><body><p>Hello</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Collections.HTMLCollection styleElements = document.GetElementsByTagName("style");

            for (int i = styleElements.Length - 1; i >= 0; i--)
            {
                Aspose.Html.Dom.Element style = (Aspose.Html.Dom.Element)styleElements[i];
                if (string.IsNullOrWhiteSpace(style.TextContent))
                {
                    if (style.ParentNode != null)
                    {
                        style.ParentNode.RemoveChild(style);
                    }
                }
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            System.Console.WriteLine("Empty <style> tags removed. Result saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}