// Implement asynchronous file download using Document.SendAsync and await the response before saving.

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        try
        {
            string urlString = "https://example.com/sample.txt";
            string outputPath = "downloaded_sample.txt";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
            {
                Aspose.Html.Url url = new Aspose.Html.Url(urlString);
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);

                Aspose.Html.Net.ResponseMessage response = await Task.Run(() => document.Context.Network.Send(request));

                if (response.IsSuccess)
                {
                    byte[] contentBytes = response.Content.ReadAsByteArray();
                    File.WriteAllBytes(outputPath, contentBytes);
                    Console.WriteLine($"File downloaded and saved to '{outputPath}'.");
                }
                else
                {
                    Console.WriteLine($"Failed to download. Status code: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}