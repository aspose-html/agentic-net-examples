// Perform an HTTP GET request to retrieve JSON data from an API endpoint and store the response.

using System;
using System.Text;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // Create a blank HTMLDocument to obtain a network context
            HTMLDocument document = new HTMLDocument();

            // Define the API endpoint URL
            Url url = new Url("https://api.example.com/data");

            // Build the GET request message
            RequestMessage request = new RequestMessage(url);

            // Send the request using the document's network context
            ResponseMessage response = document.Context.Network.Send(request);

            // Verify that the request succeeded
            bool isSuccess = response.IsSuccess;

            if (isSuccess)
            {
                // Read the response content as a byte array
                byte[] contentBytes = response.Content.ReadAsByteArray();

                // Convert the byte array to a UTF‑8 string (JSON payload)
                string json = Encoding.UTF8.GetString(contentBytes);

                // Store or process the JSON data as needed
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine($"Request failed with status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}