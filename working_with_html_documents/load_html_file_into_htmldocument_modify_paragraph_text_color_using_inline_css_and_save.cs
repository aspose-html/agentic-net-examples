// Load an HTML file into an HTMLDocument, modify paragraph text color using inline CSS, and save.

using System;
using System.Linq;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML file into an HTMLDocument
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("input.html");

            // Retrieve the first <p> element
            Aspose.Html.HTMLElement paragraph = (Aspose.Html.HTMLElement)document.GetElementsByTagName("p").First();

            // Apply inline CSS to change the text color
            paragraph.Style.Color = "#8b0000";

            // Save the modified document
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}