// Save each downloaded image to a specified output folder preserving original filenames.

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
            // Specify the output folder and ensure it exists
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "DownloadedImages");
            Directory.CreateDirectory(outputFolder);

            // List of image URLs to download
            string[] imageUrls = new string[]
            {
                "https://example.com/images/photo1.jpg",
                "https://example.com/images/photo2.png"
            };

            using HttpClient client = new HttpClient();

            foreach (string url in imageUrls)
            {
                // Preserve the original filename from the URL
                string fileName = Path.GetFileName(new Uri(url).AbsolutePath);
                string outputPath = Path.Combine(outputFolder, fileName);

                // Download the image data
                byte[] data = await client.GetByteArrayAsync(url);

                // Save the image to the output folder
                await File.WriteAllBytesAsync(outputPath, data);
            }

            Console.WriteLine("All images have been downloaded and saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}