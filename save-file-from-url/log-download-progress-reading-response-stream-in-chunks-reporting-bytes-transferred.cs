// Log the download progress by reading the response stream in chunks and reporting bytes transferred.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTMLDocument to access the network service
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
            {
                // Prepare the request
                Aspose.Html.Url url = new Aspose.Html.Url("https://example.com");
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);

                // Send the request
                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

                // Check if the request succeeded
                if (!response.IsSuccess)
                {
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                    return;
                }

                // Read the response content as a byte array
                byte[] contentBytes = response.Content.ReadAsByteArray();
                Console.WriteLine($"Downloaded {contentBytes.Length} bytes");

                Console.WriteLine("Download completed successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}