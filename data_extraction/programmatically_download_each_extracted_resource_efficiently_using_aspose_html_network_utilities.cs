// Programmatically download each extracted resource efficiently using Aspose.HTML network utilities.

using System;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // List of resource URLs to download
            string[] resourceUrls = new string[]
            {
                "https://example.com/resource1.bin",
                "https://example.com/resource2.bin"
            };

            foreach (var resourceUrl in resourceUrls)
            {
                // Create a blank HTMLDocument to obtain a network context
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

                // Create a URL object for the target resource
                Aspose.Html.Url url = new Aspose.Html.Url(resourceUrl);

                // Build a request message for the URL
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);

                // Send the request using the document's network context
                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

                // Check if the request succeeded
                bool isSuccess = response.IsSuccess;

                if (isSuccess)
                {
                    // Read the response content as a byte array
                    byte[] contentBytes = response.Content.ReadAsByteArray();

                    // Example: process the downloaded bytes (e.g., save to a file)
                    // string fileName = System.IO.Path.GetFileName(url.ToString());
                    // System.IO.File.WriteAllBytes(fileName, contentBytes);
                }
                else
                {
                    // Handle download failure if needed
                    Console.WriteLine($"Failed to download: {resourceUrl}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}