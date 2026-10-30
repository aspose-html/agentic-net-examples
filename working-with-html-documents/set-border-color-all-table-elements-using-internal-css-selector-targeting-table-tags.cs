// Set border-color for all table elements using an internal CSS selector targeting table tags.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head></head><body><table><tr><td>Cell</td></tr></table></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            var styleElement = document.CreateElement("style");
            var styleHtmlElement = (Aspose.Html.HTMLElement)styleElement;
            styleHtmlElement.InnerHTML = "table { border-color: red; }";
            var head = document.QuerySelector("head");
            head.AppendChild(styleElement);
            document.Save("output.html");
            Console.WriteLine("HTML document saved to output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}