// Provide a progress callback delegate to report percentage completed during download.

using System;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // Progress callback delegate
            Action<int> progressCallback = percent => Console.WriteLine($"Download progress: {percent}%");

            // URL of the resource to download
            string urlString = "https://example.com/file.bin";

            // Create a blank HTMLDocument required for network context
            HTMLDocument document = new HTMLDocument();

            // Create a Url object for the target resource
            Url url = new Url(urlString);

            // Build a request message
            RequestMessage request = new RequestMessage(url);

            // Send the request and receive the response
            ResponseMessage response = document.Context.Network.Send(request);

            // Check if the request was successful
            bool isSuccess = response.IsSuccess;

            if (!isSuccess)
            {
                Console.WriteLine("Download failed.");
                return;
            }

            // Read the response content as a byte array
            byte[] contentBytes = response.Content.ReadAsByteArray();

            // Report completion progress
            progressCallback(100);

            // Optionally, save the downloaded data to a file
            System.IO.File.WriteAllBytes("downloaded_file.bin", contentBytes);
            Console.WriteLine("File saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}