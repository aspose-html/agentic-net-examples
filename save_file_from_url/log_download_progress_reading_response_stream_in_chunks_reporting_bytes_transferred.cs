// Log the download progress by reading the response stream in chunks and reporting bytes transferred.

using System;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // Initialize a blank HTMLDocument required for network context
            HTMLDocument document = new HTMLDocument();

            // URL of the resource to download
            Url url = new Url("https://example.com/file.bin");

            // Build the request message
            RequestMessage request = new RequestMessage(url);

            // Send the request and receive the response
            ResponseMessage response = document.Context.Network.Send(request);

            // Check if the request was successful
            bool isSuccess = response.IsSuccess;
            if (isSuccess)
            {
                // Read the response content as a stream and log progress
                using (var stream = response.Content.ReadAsStream())
                {
                    const int bufferSize = 8192;
                    byte[] buffer = new byte[bufferSize];
                    long totalBytes = 0;
                    int bytesRead;
                    while ((bytesRead = stream.Read(buffer, 0, bufferSize)) > 0)
                    {
                        totalBytes += bytesRead;
                        Console.WriteLine($"Downloaded {totalBytes} bytes");
                    }
                }
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