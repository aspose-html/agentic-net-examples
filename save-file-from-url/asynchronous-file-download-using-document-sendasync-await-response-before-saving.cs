// Implement asynchronous file download using Document.SendAsync and await the response before saving.

using System;
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
            string url = "https://example.com/sample.bin";
            string outputPath = "downloaded_file.bin";

            using (HTMLDocument document = new HTMLDocument())
            {
                Url requestUrl = new Url(url);
                RequestMessage request = new RequestMessage(requestUrl);

                ResponseMessage response = await Task.Run(() => document.Context.Network.Send(request));

                if (response.IsSuccess)
                {
                    byte[] contentBytes = response.Content.ReadAsByteArray();
                    File.WriteAllBytes(outputPath, contentBytes);
                    Console.WriteLine($"File downloaded successfully to '{outputPath}'.");
                }
                else
                {
                    Console.WriteLine($"Failed to download file. Status code: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}