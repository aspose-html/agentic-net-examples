// Create a style element, define a CSS variable for primary color, and use it in multiple rules.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string documentPath = "sample.html";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);
            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = ":root { --primary-color: #3498db; } .header { color: var(--primary-color); } .button { background-color: var(--primary-color); }";
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}