// Use WebClient as a fallback when HttpClient download fails.

using System;
using System.Net;
using System.Net.Http;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            string htmlContent = null;

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(30);
                    htmlContent = httpClient.GetStringAsync(url).GetAwaiter().GetResult();
                }
            }
            catch (Exception)
            {
                using (WebClient webClient = new WebClient())
                {
                    htmlContent = webClient.DownloadString(url);
                }
            }

            // Use Aspose.Html to load the document from the URL
            RequestMessage request = new RequestMessage(url);
            request.Timeout = TimeSpan.FromSeconds(30);
            using (HTMLDocument document = new HTMLDocument(request))
            {
                string html = ((HTMLElement)document.DocumentElement).OuterHTML;
                Console.WriteLine(html);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}