// Convert downloaded image bytes to Base64 strings for embedding into JSON payloads.

using System;
using System.Text.Json;

class Program
{
    static void Main()
    {
        try
        {
            // Simulate downloaded image bytes (e.g., a minimal JPEG header)
            byte[] imageBytes = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0, 0x00, 0x10, 0x4A, 0x46, 0x49, 0x46, 0x00, 0x01 };

            // Convert to Base64 string
            string base64String = Convert.ToBase64String(imageBytes);

            // Create JSON payload with the Base64 image
            var payload = new { image = base64String };
            string json = JsonSerializer.Serialize(payload);

            // Output the JSON
            Console.WriteLine(json);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}