// Validate that the saved file exists and its size matches the Content-Length header.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // URL of the file to download
            string fileUrl = "https://example.com/sample.pdf";

            // Destination path for the saved file
            string outputPath = "sample.pdf";

            // Create an HttpClient to request the file
            using HttpClient client = new HttpClient();

            // Send a HEAD request to obtain the Content-Length header
            using HttpResponseMessage headResponse = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, fileUrl));
            headResponse.EnsureSuccessStatusCode();

            // Retrieve the Content-Length value
            long? contentLengthHeader = headResponse.Content.Headers.ContentLength;
            if (!contentLengthHeader.HasValue)
                throw new InvalidOperationException("Content-Length header is missing.");

            long expectedLength = contentLengthHeader.Value;

            // Download the file content
            byte[] fileBytes = await client.GetByteArrayAsync(fileUrl);

            // Save the downloaded bytes to disk
            await File.WriteAllBytesAsync(outputPath, fileBytes);

            // Verify that the file exists
            if (!File.Exists(outputPath))
                throw new FileNotFoundException("The file was not saved correctly.", outputPath);

            // Verify that the file size matches the Content-Length header
            long actualLength = new FileInfo(outputPath).Length;
            if (actualLength != expectedLength)
                throw new InvalidOperationException($"File size mismatch: expected {expectedLength} bytes, but got {actualLength} bytes.");

            Console.WriteLine("File saved successfully and size matches the Content-Length header.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}