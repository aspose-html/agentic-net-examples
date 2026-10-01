// Parse an HTML string with case‑insensitive tag handling and preserve original whitespace formatting.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<DIV>   <p>Sample</p>   </DIV>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");
            string output = document.DocumentElement.OuterHTML;
            Console.WriteLine(output);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}