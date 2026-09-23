// Register HtmlDocument and HttpClient services via dependency injection for testability.

using System;
using System.Net.Http;

class Program
{
    static void Main()
    {
        try
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://example.com");

            string htmlContent = LoadHtml();

            using (Aspose.Html.HTMLDocument document = CreateDocument(htmlContent, "http://example.com"))
            {
                string outerHtml = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
                Console.WriteLine("Outer HTML:");
                Console.WriteLine(outerHtml);
            }

            Console.WriteLine("HttpClient BaseAddress: " + (httpClient.BaseAddress?.ToString() ?? "null"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static Aspose.Html.HTMLDocument CreateDocument(string htmlContent, string baseUrl)
    {
        return new Aspose.Html.HTMLDocument(htmlContent, baseUrl);
    }

    static string LoadHtml()
    {
        return "<html><body><h1>Hello World</h1></body></html>";
    }
}