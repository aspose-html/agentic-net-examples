// Detect and correct malformed tags such as missing closing brackets during parsing.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><div><p>Test</div></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Dom.Element rootElement = document.DocumentElement;
            Aspose.Html.HTMLElement htmlElement = (Aspose.Html.HTMLElement)rootElement;
            string correctedHtml = htmlElement.OuterHTML;
            Console.WriteLine("Corrected HTML:");
            Console.WriteLine(correctedHtml);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}