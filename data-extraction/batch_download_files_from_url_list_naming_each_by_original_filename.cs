// Batch download files from a list of URLs, naming each file based on its original filename.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] urls = new string[]
            {
                "https://example.com/file1.pdf",
                "https://example.com/image.png"
            };

            string outputFolder = "DownloadedFiles";
            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            foreach (string urlString in urls)
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
                {
                    Aspose.Html.Url url = new Aspose.Html.Url(urlString);
                    Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
                    Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

                    if (response.IsSuccess)
                    {
                        byte[] contentBytes = response.Content.ReadAsByteArray();
                        string fileName = System.IO.Path.GetFileName(urlString);
                        string savePath = System.IO.Path.Combine(outputFolder, fileName);
                        System.IO.File.WriteAllBytes(savePath, contentBytes);
                        System.Console.WriteLine($"Downloaded: {fileName}");
                    }
                    else
                    {
                        System.Console.WriteLine($"Failed to download {urlString}: {response.StatusCode}");
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}