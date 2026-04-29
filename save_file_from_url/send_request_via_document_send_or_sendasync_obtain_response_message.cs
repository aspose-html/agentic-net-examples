// Send the request via Document.Send (or SendAsync) and obtain a ResponseMessage.

using System;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // Initialize an empty HTMLDocument to obtain a network context
            using (HTMLDocument document = new HTMLDocument())
            {
                // Define the target URL
                Url url = new Url("https://example.com/file.bin");

                // Create a request message for the URL
                RequestMessage request = new RequestMessage(url);

                // Send the request and receive the response
                ResponseMessage response = document.Context.Network.Send(request);

                // Check if the request was successful
                bool isSuccess = response.IsSuccess;

                // Read the response content as a byte array
                byte[] contentBytes = response.Content.ReadAsByteArray();

                Console.WriteLine($"Request success: {isSuccess}, bytes received: {contentBytes?.Length ?? 0}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}