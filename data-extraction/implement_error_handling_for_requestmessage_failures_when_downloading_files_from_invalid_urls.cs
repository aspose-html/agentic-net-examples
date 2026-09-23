// Implement error handling for RequestMessage failures when downloading files from invalid URLs.

using System;
using System.Net;

class Program
{
    static void Main()
    {
        try
        {
            // Create an empty HTML document to obtain a network context
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
            {
                // URL to download (intentionally invalid)
                string urlString = "http://invalid-url.example.com/file.html";
                Aspose.Html.Url url = new Aspose.Html.Url(urlString);

                // Create request message
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);

                // Send request
                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

                // Check if request succeeded
                if (response.IsSuccess)
                {
                    byte[] contentBytes = response.Content.ReadAsByteArray();
                    string content = System.Text.Encoding.UTF8.GetString(contentBytes);
                    Console.WriteLine("Download succeeded. Content length: " + contentBytes.Length);
                }
                else
                {
                    Console.WriteLine($"Download failed. Status code: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}