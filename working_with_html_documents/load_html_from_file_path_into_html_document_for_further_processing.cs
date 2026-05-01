// Load HTML from a file path into an HTMLDocument for further processing.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("input.html");
            string htmlContent = document.DocumentElement.OuterHTML;
            Console.WriteLine(htmlContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}