// Implement error handling for RequestMessage failures when downloading files from invalid URLs.

using System;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // Initialize a blank HTMLDocument to obtain a network context
            HTMLDocument document = new HTMLDocument();

            // Define the URL of the file to download (intentionally invalid)
            Url url = new Url("https://invalid.example.com/file.bin");

            // Create a request message for the URL
            RequestMessage request = new RequestMessage(url);

            // Send the request using the document's network context
            ResponseMessage response = document.Context.Network.Send(request);

            // Determine whether the request succeeded
            bool isSuccess = response.IsSuccess;

            if (isSuccess)
            {
                // Read the response content as a byte array
                byte[] contentBytes = response.Content.ReadAsByteArray();
                Console.WriteLine($"Download succeeded. Received {contentBytes.Length} bytes.");
            }
            else
            {
                // Handle failure by reporting the status code
                Console.WriteLine($"Download failed. Status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            // Catch any unexpected exceptions and display the message
            Console.WriteLine($"Exception occurred: {ex.Message}");
        }
    }
}