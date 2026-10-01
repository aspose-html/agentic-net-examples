// Detect and correct malformed tags such as missing closing brackets during parsing.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>Paragraph<div>Div without closing tags";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");

            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)document.Body;
            string correctedHtml = body.OuterHTML;

            Console.WriteLine("Corrected HTML:");
            Console.WriteLine(correctedHtml);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}