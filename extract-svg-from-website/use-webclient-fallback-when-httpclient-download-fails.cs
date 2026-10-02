// Use WebClient as a fallback when HttpClient download fails.

using System;
using System.Net.Http;
using System.Net;
using System.Text;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            byte[] contentBytes = null;

            // Try downloading with HttpClient
            try
            {
                using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
                {
                    System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> responseTask = httpClient.GetAsync(url);
                    responseTask.Wait();
                    System.Net.Http.HttpResponseMessage response = responseTask.Result;
                    response.EnsureSuccessStatusCode();
                    System.Threading.Tasks.Task<byte[]> readTask = response.Content.ReadAsByteArrayAsync();
                    readTask.Wait();
                    contentBytes = readTask.Result;
                }
            }
            catch (Exception)
            {
                // Fallback to WebClient
                using (System.Net.WebClient webClient = new System.Net.WebClient())
                {
                    contentBytes = webClient.DownloadData(url);
                }
            }

            if (contentBytes == null || contentBytes.Length == 0)
            {
                Console.WriteLine("Failed to download content.");
                return;
            }

            string htmlContent = System.Text.Encoding.UTF8.GetString(contentBytes);
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            string outerHtml = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
            Console.WriteLine(outerHtml);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}