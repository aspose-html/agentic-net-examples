// Create a RequestMessage with custom headers and use it to download an image file from a URL.

using System;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the image to download
            string urlString = "https://example.com/image.jpg";
            // Local file path to save the downloaded image
            string outputPath = "image.jpg";

            // Create a blank HTMLDocument to obtain a network context
            HTMLDocument document = new HTMLDocument();

            // Create a Url object for the target resource
            Url url = new Url(urlString);

            // Build a RequestMessage and add custom headers
            RequestMessage request = new RequestMessage(url);
            request.Headers.Add("User-Agent", "Aspose-HTML-Client");
            request.Headers.Add("Accept", "image/*");

            // Send the request using the document's network context
            ResponseMessage response = document.Context.Network.Send(request);

            // Check if the request succeeded
            if (response.IsSuccess)
            {
                // Read the response content as a byte array
                byte[] contentBytes = response.Content.ReadAsByteArray();
                // Save the downloaded image to disk
                System.IO.File.WriteAllBytes(outputPath, contentBytes);
                Console.WriteLine("Image downloaded successfully.");
            }
            else
            {
                Console.WriteLine($"Download failed. Status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}