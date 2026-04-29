// Implement asynchronous file download using Document.SendAsync and await the response before saving.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static async Task Main()
    {
        try
        {
            // URL of the file to download
            var fileUrl = new Url("https://example.com/file.bin");

            // Create a request message for the URL
            var request = new RequestMessage(fileUrl);

            // Create an empty HTMLDocument to obtain the network context
            using var document = new HTMLDocument();

            // Send the request asynchronously (wrapped in Task.Run because Send is synchronous)
            var response = await Task.Run(() => document.Context.Network.Send(request));

            // Verify that the request succeeded
            if (response.IsSuccess)
            {
                // Read the downloaded content as a byte array
                byte[] data = response.Content.ReadAsByteArray();

                // Save the downloaded file to disk
                string outputPath = Path.Combine(Environment.CurrentDirectory, "downloaded.bin");
                await File.WriteAllBytesAsync(outputPath, data);

                Console.WriteLine($"File downloaded successfully to: {outputPath}");
            }
            else
            {
                Console.WriteLine($"Download failed. Status: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}