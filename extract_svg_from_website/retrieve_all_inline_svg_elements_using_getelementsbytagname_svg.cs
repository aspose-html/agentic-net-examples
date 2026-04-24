// Retrieve all inline <svg> elements with document.GetElementsByTagName("svg").

using System;
using Aspose.Html;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com");
            Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");
            Console.WriteLine($"Number of inline SVG elements: {svgs.Length}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}