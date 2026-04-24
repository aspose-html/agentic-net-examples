// Use WebClient as a fallback when HttpClient download fails.

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        try
        {
            string url = "https://example.com/resource.bin";

            byte[] data;

            // Try downloading with HttpClient
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    data = await httpClient.GetByteArrayAsync(url);
                    Console.WriteLine($"Downloaded {data.Length} bytes using HttpClient.");
                }
                catch (Exception httpEx)
                {
                    Console.WriteLine($"HttpClient failed: {httpEx.Message}");
                    // Fallback to WebClient
                    using (WebClient webClient = new WebClient())
                    {
                        data = webClient.DownloadData(url);
                        Console.WriteLine($"Downloaded {data.Length} bytes using WebClient.");
                    }
                }
            }

            // Further processing of 'data' can be placed here
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}