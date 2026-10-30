// Use WebClient as a fallback when HttpClient download fails.

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string url = "https://example.com";
            string htmlContent;

            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                try
                {
                    htmlContent = await httpClient.GetStringAsync(url);
                }
                catch (Exception)
                {
                    using (var webClient = new WebClient())
                    {
                        webClient.Encoding = System.Text.Encoding.UTF8;
                        htmlContent = webClient.DownloadString(url);
                    }
                }
            }

            using (var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                string outerHtml = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
                Console.WriteLine(outerHtml);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}