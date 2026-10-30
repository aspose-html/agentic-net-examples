// Parse the <base> tag in the HTML document to correctly resolve relative SVG URLs.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><base href=\"https://example.com/assets/\"/></head><body><svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><image href=\"images/pic.png\" width=\"100\" height=\"100\"/></svg></body></html>";
            Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(html, "about:blank");
            string outHtml = document.DocumentElement.OuterHTML;
            System.Console.WriteLine(outHtml);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}