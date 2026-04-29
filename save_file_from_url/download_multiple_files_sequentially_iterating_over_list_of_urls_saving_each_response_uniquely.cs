// Download multiple files sequentially by iterating over a list of URLs and saving each response uniquely.

using System;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            string[] urls = new string[]
            {
                "https://example.com/file1.bin",
                "https://example.com/file2.bin",
                "https://example.com/file3.bin"
            };

            for (int index = 0; index < urls.Length; index++)
            {
                // Create a blank HTMLDocument to obtain a network context
                HTMLDocument document = new HTMLDocument();

                // Prepare the target URL
                Url url = new Url(urls[index]);

                // Build the request message
                RequestMessage request = new RequestMessage(url);

                // Send the request using the document's browsing context network
                ResponseMessage response = document.Context.Network.Send(request);

                // Check if the request was successful
                bool isSuccess = response.IsSuccess;

                if (isSuccess)
                {
                    // Read the response content as a byte array
                    byte[] contentBytes = response.Content.ReadAsByteArray();

                    // Output information about the downloaded content
                    Console.WriteLine($"[{index + 1}/{urls.Length}] Download succeeded: {url}");
                    Console.WriteLine($"Size: {contentBytes.Length} bytes");
                }
                else
                {
                    Console.WriteLine($"[{index + 1}/{urls.Length}] Download failed: {url}");
                }

                // Dispose the document (optional, as it implements IDisposable)
                document.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}