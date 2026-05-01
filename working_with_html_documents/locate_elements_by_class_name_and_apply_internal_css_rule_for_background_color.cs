// Locate elements by class name and apply an internal CSS rule for background-color.

using System;
using Aspose.Html;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            HTMLDocument document = new HTMLDocument("input.html");
            NodeList elements = document.QuerySelectorAll(".myClass");
            foreach (HTMLElement element in elements)
            {
                element.Style.BackgroundColor = "#ff0000";
            }
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}