// Load an HTML document from a URL using custom network timeout, and handle timeout exceptions gracefully.

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string url = "https://example.com";
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
                request.Timeout = System.TimeSpan.FromSeconds(10);
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request);
                string html = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
                System.Console.WriteLine(html);
            }
            catch (System.Exception ex)
            {
                if (ex.Message.Contains("timed out"))
                {
                    System.Console.WriteLine("The request timed out.");
                }
                else
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }
    }
}