// Convert downloaded image bytes to Base64 strings for embedding into JSON payloads.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample image bytes (PNG header)
            byte[] imageBytes = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
            string base64String = Convert.ToBase64String(imageBytes);
            string jsonPayload = $"{{\"image\":\"{base64String}\"}}";
            Console.WriteLine(jsonPayload);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}