// Implement try‑catch error handling when loading an HTML file that may not exist.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        string filePath = "sample.html";
        try
        {
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(filePath);
            string htmlContent = document.DocumentElement.OuterHTML;
            Console.WriteLine(htmlContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading HTML file: {ex.Message}");
        }
    }
}