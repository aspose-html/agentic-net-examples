// Create a FileStream for the destination path and copy the response stream to it.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        try
        {
            string url = "https://example.com/file";
            string outputPath = "output.dat";

            using (HttpClient client = new HttpClient())
            using (Stream responseStream = await client.GetStreamAsync(url))
            using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                await responseStream.CopyToAsync(fileStream);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}