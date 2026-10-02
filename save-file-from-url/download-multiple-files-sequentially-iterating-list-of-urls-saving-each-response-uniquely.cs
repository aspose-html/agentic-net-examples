// Download multiple files sequentially by iterating over a list of URLs and saving each response uniquely.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            List<string> urls = new List<string>
            {
                "https://example.com/file1.txt",
                "https://example.com/file2.jpg"
            };

            string outputDir = "DownloadedFiles";
            Directory.CreateDirectory(outputDir);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
            {
                foreach (string urlString in urls)
                {
                    Aspose.Html.Url url = new Aspose.Html.Url(urlString);
                    Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
                    Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

                    if (response.IsSuccess)
                    {
                        byte[] contentBytes = response.Content.ReadAsByteArray();

                        string fileName = Path.GetFileName(urlString);
                        if (string.IsNullOrEmpty(fileName))
                        {
                            fileName = $"file_{Guid.NewGuid()}.bin";
                        }

                        string savePath = Path.Combine(outputDir, fileName);
                        File.WriteAllBytes(savePath, contentBytes);
                        Console.WriteLine($"Saved: {savePath}");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to download: {urlString}, Status: {response.StatusCode}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}