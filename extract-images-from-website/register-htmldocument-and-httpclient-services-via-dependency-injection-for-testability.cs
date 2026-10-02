// Register HtmlDocument and HttpClient services via dependency injection for testability.

using System;

class Program
{
    static Aspose.Html.HTMLDocument CreateDocument(string htmlContent, string baseUrl)
    {
        return new Aspose.Html.HTMLDocument(htmlContent, baseUrl);
    }

    static string LoadHtml()
    {
        return "<html><body><h1>Hello, Aspose!</h1></body></html>";
    }

    static void Main()
    {
        try
        {
            using (Aspose.Html.HTMLDocument document = CreateDocument(LoadHtml(), "about:blank"))
            {
                string outerHtml = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
                Console.WriteLine(outerHtml);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}