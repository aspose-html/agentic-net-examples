// Load an HTML document from a file path into a DOM object.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string filePath = "sample.html";
            using (HTMLDocument document = new HTMLDocument(filePath))
            {
                string htmlContent = document.DocumentElement.OuterHTML;
                Console.WriteLine(htmlContent);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}