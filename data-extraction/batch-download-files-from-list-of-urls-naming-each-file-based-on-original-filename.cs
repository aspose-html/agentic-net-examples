// Batch download files from a list of URLs, naming each file based on its original filename.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string[] urls = new string[]
            {
                "https://example.com/file1.pdf",
                "https://example.com/image.jpg"
            };

            string outputFolder = "DownloadedFiles";
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            foreach (string urlString in urls)
            {
                try
                {
                    Aspose.Html.Url url = new Aspose.Html.Url(urlString);
                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
                    {
                        Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
                        Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

                        if (response.IsSuccess)
                        {
                            byte[] contentBytes = response.Content.ReadAsByteArray();
                            string fileName = Path.GetFileName(urlString);
                            string savePath = Path.Combine(outputFolder, fileName);
                            File.WriteAllBytes(savePath, contentBytes);
                            Console.WriteLine($"Downloaded: {fileName}");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to download {urlString}: HTTP {(int)response.StatusCode}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing {urlString}: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}