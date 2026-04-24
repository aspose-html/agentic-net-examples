// Batch download files from a list of URLs, naming each file based on its original filename.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            string[] urls = new string[]
            {
                "https://example.com/file1.pdf",
                "https://example.com/image.png"
            };
            string outputFolder = "DownloadedFiles";
            Directory.CreateDirectory(outputFolder);
            foreach (string urlString in urls)
            {
                HTMLDocument document = new HTMLDocument();
                Url url = new Url(urlString);
                RequestMessage request = new RequestMessage(url);
                ResponseMessage response = document.Context.Network.Send(request);
                if (response.IsSuccess)
                {
                    byte[] contentBytes = response.Content.ReadAsByteArray();
                    string fileName = Path.GetFileName(urlString);
                    string outputPath = Path.Combine(outputFolder, fileName);
                    File.WriteAllBytes(outputPath, contentBytes);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}