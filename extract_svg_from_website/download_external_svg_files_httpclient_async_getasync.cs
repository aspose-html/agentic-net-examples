// Download external SVG files using HttpClient with asynchronous GetAsync calls.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

namespace SvgDownloader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // URLs of SVG files to download
                var svgUrls = new[]
                {
                    "https://example.com/image1.svg",
                    "https://example.com/image2.svg"
                };

                using var httpClient = new HttpClient();

                foreach (var url in svgUrls)
                {
                    // Asynchronously download the SVG content
                    using var response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    // Read the response as a byte array
                    var content = await response.Content.ReadAsByteArrayAsync();

                    // Derive a file name from the URL
                    var fileName = Path.GetFileName(new Uri(url).LocalPath);
                    if (string.IsNullOrEmpty(fileName))
                    {
                        fileName = $"svg_{Guid.NewGuid()}.svg";
                    }

                    // Save the SVG to the local file system
                    await File.WriteAllBytesAsync(fileName, content);
                    Console.WriteLine($"Downloaded and saved: {fileName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}