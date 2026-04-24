// Download a PDF file from a given URL using RequestMessage and save it with ResponseMessage.

using System;
using System.IO;
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

            // URL of the PDF file to download
            Url url = new Url("https://example.com/file.pdf");

            // Build the request message
            RequestMessage request = new RequestMessage(url);

            // Send the request and receive the response
            ResponseMessage response = document.Context.Network.Send(request);

            // Verify that the request succeeded
            bool isSuccess = response.IsSuccess;
            if (!isSuccess)
            {
                Console.WriteLine("Download failed.");
                return;
            }

            // Read the response content as a byte array
            byte[] contentBytes = response.Content.ReadAsByteArray();

            // Save the downloaded PDF to disk
            File.WriteAllBytes("downloaded.pdf", contentBytes);
            Console.WriteLine("File saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}