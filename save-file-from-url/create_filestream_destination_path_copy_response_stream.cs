// Create a FileStream for the destination path and copy the response stream to it.

using System;
using System.IO;
using System.Net.Http;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            string outputPath = "example.html";

            using (HttpClient httpClient = new HttpClient())
            using (HttpResponseMessage response = httpClient.GetAsync(url).GetAwaiter().GetResult())
            using (Stream responseStream = response.Content.ReadAsStreamAsync().GetAwaiter().GetResult())
            using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                responseStream.CopyTo(fileStream);
            }

            Console.WriteLine("Download completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}