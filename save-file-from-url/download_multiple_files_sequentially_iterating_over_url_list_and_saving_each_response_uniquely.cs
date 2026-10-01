// Download multiple files sequentially by iterating over a list of URLs and saving each response uniquely.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var urls = new List<string>
            {
                "https://example.com/file1.txt",
                "https://example.com/file2.jpg"
            };

            string outputDir = "DownloadedFiles";
            Directory.CreateDirectory(outputDir);

            using (HTMLDocument document = new HTMLDocument())
            {
                int index = 1;
                foreach (string urlString in urls)
                {
                    Url url = new Url(urlString);
                    RequestMessage request = new RequestMessage(url);
                    ResponseMessage response = document.Context.Network.Send(request);

                    if (response.IsSuccess)
                    {
                        byte[] contentBytes = response.Content.ReadAsByteArray();
                        string fileName = Path.GetFileName(urlString);
                        if (string.IsNullOrEmpty(fileName))
                        {
                            fileName = $"file_{index}";
                        }
                        string savePath = Path.Combine(outputDir, fileName);
                        File.WriteAllBytes(savePath, contentBytes);
                        Console.WriteLine($"Saved: {savePath}");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to download: {urlString}, Status: {response.StatusCode}");
                    }

                    index++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}