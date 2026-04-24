// Implement parallel image download using Task.WhenAll to improve overall extraction performance.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string htmlPath = "input.html";
            HTMLDocument document = new HTMLDocument(htmlPath);
            HTMLCollection images = document.GetElementsByTagName("img");
            string outputDir = "images";
            Directory.CreateDirectory(outputDir);
            using HttpClient httpClient = new HttpClient();

            Task[] downloadTasks = new Task[images.Length];
            for (int i = 0; i < images.Length; i++)
            {
                Element imgElement = (Element)images[i];
                string src = imgElement.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                    continue;

                Url imageUrl = new Url(src, document.BaseURI);
                string urlString = imageUrl.ToString();
                string extension = Path.GetExtension(urlString);
                if (!extension.Equals(".png", StringComparison.OrdinalIgnoreCase) &&
                    !extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                    !extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase))
                    continue;

                downloadTasks[i] = Task.Run(async () =>
                {
                    byte[] imageBytes = await httpClient.GetByteArrayAsync(urlString);
                    string fileName = Path.GetFileName(urlString);
                    string savePath = Path.Combine(outputDir, fileName);
                    await File.WriteAllBytesAsync(savePath, imageBytes);
                });
            }

            await Task.WhenAll(downloadTasks);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}