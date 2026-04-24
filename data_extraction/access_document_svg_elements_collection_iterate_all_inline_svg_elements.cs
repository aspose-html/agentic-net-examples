// Access the document's SVG elements collection to iterate over all inline <svg> elements.

using System;
using Aspose.Html;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            HTMLDocument document = new HTMLDocument(url);
            HTMLCollection svgs = document.GetElementsByTagName("svg");
            for (int i = 0; i < svgs.Length; i++)
            {
                Console.WriteLine($"Found SVG element #{i}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}