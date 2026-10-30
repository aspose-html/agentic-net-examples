// Download multiple files sequentially by iterating over a list of URLs and saving each response uniquely.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // List of URLs to download
            List<string> urlList = new List<string>
            {
                "https://example.com/file1.txt",
                "https://example.com/file2.txt",
                "https://example.com/file3.txt"
            };

            // Output directory
            string outputDir = "DownloadedFiles";
            Directory.CreateDirectory(outputDir);

            // Create a single HTMLDocument to use its network context
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
            {
                for (int i = 0; i < urlList.Count; i++)
                {
                    string urlString = urlList[i];
                    Aspose.Html.Url url = new Aspose.Html.Url(urlString);
                    Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
                    Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

                    bool isSuccess = response.IsSuccess;
                    if (!isSuccess)
                    {
                        Console.WriteLine($"Failed to download: {urlString}");
                        continue;
                    }

                    byte[] contentBytes = response.Content.ReadAsByteArray();

                    // Determine a unique file name
                    string fileName = Path.GetFileName(new Uri(urlString).AbsolutePath);
                    if (string.IsNullOrEmpty(fileName))
                    {
                        fileName = $"downloaded_{i}";
                    }

                    string outputPath = Path.Combine(outputDir, fileName);
                    File.WriteAllBytes(outputPath, contentBytes);
                    Console.WriteLine($"Saved: {outputPath}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}