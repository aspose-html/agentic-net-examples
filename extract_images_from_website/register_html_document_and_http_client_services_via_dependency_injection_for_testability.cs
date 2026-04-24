// Register HtmlDocument and HttpClient services via dependency injection for testability.

using System;
using System.Net.Http;
using Aspose.Html;

class ServiceContainer
{
    public Func<string, string, HTMLDocument> HtmlDocumentFactory { get; set; }
    public HttpClient HttpClient { get; set; }
}

class Program
{
    static HTMLDocument CreateDocument(string htmlContent, string baseUrl)
    {
        return new HTMLDocument(htmlContent, baseUrl);
    }

    static string LoadHtml()
    {
        return "<html><body><h1>Hello World</h1></body></html>";
    }

    static void Main()
    {
        try
        {
            var services = new ServiceContainer
            {
                HtmlDocumentFactory = CreateDocument,
                HttpClient = new HttpClient()
            };

            string html = LoadHtml();

            using (HTMLDocument document = services.HtmlDocumentFactory(html, "http://example.com"))
            {
                string outerHtml = ((HTMLElement)document.DocumentElement).OuterHTML;
                Console.WriteLine(outerHtml);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}