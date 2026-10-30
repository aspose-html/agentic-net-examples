// Implement asynchronous file download using Document.SendAsync and await the response before saving.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string url = "https://example.com/sample.html";
            string outputPath = "downloaded.html";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
            {
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(new Aspose.Html.Url(url));
                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

                if (response.IsSuccess)
                {
                    byte[] contentBytes = response.Content.ReadAsByteArray();
                    File.WriteAllBytes(outputPath, contentBytes);
                    Console.WriteLine($"File downloaded successfully to '{outputPath}'.");
                }
                else
                {
                    Console.WriteLine($"Download failed. Status code: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}