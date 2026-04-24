// Configure custom HttpClient headers, such as a User‑Agent string, before downloading resources.

using System;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            string urlString = "https://example.com/resource.bin";

            HTMLDocument document = new HTMLDocument();

            Url url = new Url(urlString);

            RequestMessage request = new RequestMessage(url);
            request.Headers.Add("User-Agent", "MyCustomUserAgent/1.0");

            ResponseMessage response = document.Context.Network.Send(request);

            bool isSuccess = response.IsSuccess;

            if (isSuccess)
            {
                byte[] contentBytes = response.Content.ReadAsByteArray();
                Console.WriteLine($"Download succeeded. Bytes received: {contentBytes.Length}");
            }
            else
            {
                Console.WriteLine("Download failed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}