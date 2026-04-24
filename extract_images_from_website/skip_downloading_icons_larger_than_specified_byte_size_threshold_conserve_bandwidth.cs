// Skip downloading icons larger than a specified byte size threshold to conserve bandwidth.

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
            string[] iconUrls = new string[]
            {
                "https://example.com/icon1.png",
                "https://example.com/icon2.png",
                "https://example.com/icon3.png"
            };
            const int maxSizeBytes = 50000;
            string outputDir = "icons";
            Directory.CreateDirectory(outputDir);
            foreach (string urlString in iconUrls)
            {
                HTMLDocument document = new HTMLDocument();
                Url url = new Url(urlString);
                RequestMessage request = new RequestMessage(url);
                ResponseMessage response = document.Context.Network.Send(request);
                bool isSuccess = response.IsSuccess;
                if (!isSuccess) continue;
                byte[] contentBytes = response.Content.ReadAsByteArray();
                if (contentBytes.Length > maxSizeBytes) continue;
                string fileName = Path.GetFileName(url.ToString());
                string savePath = Path.Combine(outputDir, fileName);
                File.WriteAllBytes(savePath, contentBytes);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}