// Create a console application that accepts a URL argument and saves the downloaded file to the current directory.

using System;
using System.IO;

namespace AsposeHtmlDownloadExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string urlString = args.Length > 0 ? args[0] : "https://example.com";
                var url = new Aspose.Html.Url(urlString);
                var document = new Aspose.Html.HTMLDocument();
                var request = new Aspose.Html.Net.RequestMessage(url);
                var response = document.Context.Network.Send(request);
                if (!response.IsSuccess)
                {
                    Console.WriteLine($"Failed to download content. Status: {response.StatusCode}");
                    return;
                }
                byte[] contentBytes = response.Content.ReadAsByteArray();
                string fileName = Path.GetFileName(new Uri(urlString).AbsolutePath);
                if (string.IsNullOrEmpty(fileName))
                {
                    fileName = "output.html";
                }
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
                File.WriteAllBytes(outputPath, contentBytes);
                Console.WriteLine($"File saved to: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}