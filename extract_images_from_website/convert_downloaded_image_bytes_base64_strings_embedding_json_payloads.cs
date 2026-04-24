// Convert downloaded image bytes to Base64 strings for embedding into JSON payloads.

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // URL of the image to download
            string imageUrl = "https://example.com/image.png";

            // Download image bytes
            byte[] imageBytes = await DownloadImageAsync(imageUrl);

            // Convert bytes to Base64 string
            string base64String = Convert.ToBase64String(imageBytes);

            // Create JSON payload with the Base64 image data
            var payload = new { ImageBase64 = base64String };
            string json = JsonSerializer.Serialize(payload);

            // Output the JSON payload
            Console.WriteLine(json);
        }
        catch (Exception ex)
        {
            // Write any errors to the error stream
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper method to download image data as a byte array
    static async Task<byte[]> DownloadImageAsync(string url)
    {
        using var httpClient = new HttpClient();
        return await httpClient.GetByteArrayAsync(url);
    }
}