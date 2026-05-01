// Create a CSS selector that targets the first paragraph element in the document.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            var document = new Aspose.Html.HTMLDocument("input.html");
            var element = document.QuerySelector("p:first-of-type");
            if (element != null)
            {
                element.SetAttribute("style", "color:rgb(50,150,200); background-color:#e1f0fe;");
            }
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}