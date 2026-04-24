// Validate that each resolved URL returns a successful HTTP status before attempting download.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            var urls = new List<string>
            {
                "https://example.com/file1.bin",
                "https://example.com/file2.bin"
            };

            foreach (var urlString in urls)
            {
                HTMLDocument document = new HTMLDocument();
                Url url = new Url(urlString);
                RequestMessage request = new RequestMessage(url);
                ResponseMessage response = document.Context.Network.Send(request);
                if (response.IsSuccess)
                {
                    byte[] content = response.Content.ReadAsByteArray();
                    Console.WriteLine($"Downloaded {urlString}, {content.Length} bytes.");
                }
                else
                {
                    Console.WriteLine($"Failed to download {urlString}, status code: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}