// Validate that the saved file exists and its size matches the Content-Length header.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // URL of the file to download
            string url = "https://www.w3.org/TR/PNG/iso_8859-1.txt";
            // Local path to save the downloaded file
            string localPath = "downloaded.txt";

            using (HttpClient client = new HttpClient())
            {
                // Get Content-Length header via HEAD request
                HttpRequestMessage headRequest = new HttpRequestMessage(HttpMethod.Head, url);
                HttpResponseMessage headResponse = await client.SendAsync(headRequest);
                headResponse.EnsureSuccessStatusCode();
                long? contentLength = headResponse.Content.Headers.ContentLength;

                // Download the file content
                HttpResponseMessage getResponse = await client.GetAsync(url);
                getResponse.EnsureSuccessStatusCode();
                byte[] data = await getResponse.Content.ReadAsByteArrayAsync();

                // Save to local file
                File.WriteAllBytes(localPath, data);

                // Validate file existence
                if (!File.Exists(localPath))
                {
                    throw new FileNotFoundException($"The file '{localPath}' was not found after saving.");
                }

                // Validate file size matches Content-Length header (if header is present)
                long fileSize = new FileInfo(localPath).Length;
                if (contentLength.HasValue && fileSize != contentLength.Value)
                {
                    throw new InvalidOperationException($"File size ({fileSize} bytes) does not match Content-Length header ({contentLength.Value} bytes).");
                }

                // Load the saved file with Aspose.HTML to demonstrate usage
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(localPath))
                {
                    // Simple operation: get text content length
                    string text = document.Body.TextContent;
                    Console.WriteLine($"Conversion verification passed. Text length: {text.Length}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}