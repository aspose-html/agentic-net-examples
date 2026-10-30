// Log the download progress by reading the response stream in chunks and reporting bytes transferred.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // Initialize HTMLDocument to access the network service
            using (HTMLDocument document = new HTMLDocument())
            {
                // Define the URL to download
                Url url = new Url("https://example.com");
                // Create request message
                RequestMessage request = new RequestMessage(url);
                // Send request and get response
                ResponseMessage response = document.Context.Network.Send(request);

                if (!response.IsSuccess)
                {
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                    return;
                }

                // Read content as byte array
                byte[] contentBytes = response.Content.ReadAsByteArray();
                long totalBytes = contentBytes.Length;
                long transferred = 0;
                const int chunkSize = 8192;

                using (MemoryStream ms = new MemoryStream(contentBytes))
                {
                    byte[] buffer = new byte[chunkSize];
                    int read;
                    while ((read = ms.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        transferred += read;
                        Console.WriteLine($"Downloaded {transferred} of {totalBytes} bytes");
                    }
                }

                Console.WriteLine("Download completed successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}