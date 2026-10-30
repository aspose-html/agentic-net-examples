// Perform an HTTP GET request to retrieve JSON data from an API endpoint and store the response.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            // Define the API endpoint and output file path
            string apiUrl = "https://jsonplaceholder.typicode.com/todos/1";
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "response.json");

            // Create a URL object
            Aspose.Html.Url url = new Aspose.Html.Url(apiUrl);

            // Initialize an empty HTMLDocument to access the network service
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Create and send the HTTP GET request
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

            // Verify the request succeeded
            if (!response.IsSuccess)
            {
                Console.Error.WriteLine($"Request failed with status code: {response.StatusCode}");
                return;
            }

            // Read response content as bytes and convert to string
            byte[] contentBytes = response.Content.ReadAsByteArray();
            string json = Encoding.UTF8.GetString(contentBytes);

            // Store the JSON response to a file
            File.WriteAllText(outputPath, json, Encoding.UTF8);
            Console.WriteLine($"JSON response saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}