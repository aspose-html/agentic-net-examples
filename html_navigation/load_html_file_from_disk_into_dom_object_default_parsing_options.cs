// Load an HTML file from disk into a DOM object using default parsing options.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string filePath = "example.html";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(filePath);
            string htmlContent = document.DocumentElement.OuterHTML;
            Console.WriteLine(htmlContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}