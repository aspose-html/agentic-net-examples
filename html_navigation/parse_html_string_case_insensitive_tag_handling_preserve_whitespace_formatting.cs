// Parse an HTML string with case‑insensitive tag handling and preserve original whitespace formatting.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<DIV>   <p>Sample Text</p>   </DIV>";
            using (HTMLDocument document = new HTMLDocument(htmlContent, ""))
            {
                string preservedHtml = document.DocumentElement.OuterHTML;
                Console.WriteLine(preservedHtml);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}