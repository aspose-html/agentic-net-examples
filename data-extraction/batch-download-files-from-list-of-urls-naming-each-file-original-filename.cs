// Batch download files from a list of URLs, naming each file based on its original filename.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            var urls = new List<string>
            {
                "https://example.com/file1.txt",
                "https://example.com/image.png"
            };

            string outputFolder = "DownloadedFiles";
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            foreach (var urlString in urls)
            {
                var url = new Aspose.Html.Url(urlString);
                var request = new Aspose.Html.Net.RequestMessage(url);
                var document = new Aspose.Html.HTMLDocument();
                var response = document.Context.Network.Send(request);
                bool isSuccess = response.IsSuccess;
                if (!isSuccess)
                {
                    Console.WriteLine($"Failed to download {urlString}: HTTP {response.StatusCode}");
                    continue;
                }

                byte[] contentBytes = response.Content.ReadAsByteArray();
                string fileName = Path.GetFileName(urlString);
                if (string.IsNullOrEmpty(fileName))
                {
                    fileName = Guid.NewGuid().ToString();
                }

                string savePath = Path.Combine(outputFolder, fileName);
                File.WriteAllBytes(savePath, contentBytes);
                Console.WriteLine($"Saved {urlString} to {savePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}