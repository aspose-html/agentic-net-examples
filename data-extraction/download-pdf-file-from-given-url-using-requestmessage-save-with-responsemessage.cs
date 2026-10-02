// Download a PDF file from a given URL using RequestMessage and save it with ResponseMessage.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com/sample.pdf";
            string outputPath = Path.Combine(Path.GetTempPath(), "downloaded.pdf");

            // Create a minimal HTMLDocument to obtain a network context
            var document = new Aspose.Html.HTMLDocument("about:blank");

            var request = new Aspose.Html.Net.RequestMessage(new Aspose.Html.Url(url));
            Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

            if (response.IsSuccess)
            {
                byte[] contentBytes = response.Content.ReadAsByteArray();
                File.WriteAllBytes(outputPath, contentBytes);
                Console.WriteLine($"PDF downloaded successfully to: {outputPath}");
            }
            else
            {
                Console.WriteLine($"Failed to download PDF. Status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}