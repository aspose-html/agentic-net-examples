// Verify the response Content-Type header matches the expected file type before saving.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com/file.pdf";
            string outputPath = "output.pdf";
            string expectedMime = "application/pdf";

            HTMLDocument document = new HTMLDocument();
            Url requestUrl = new Url(url);
            RequestMessage request = new RequestMessage(requestUrl);
            ResponseMessage response = document.Context.Network.Send(request);

            if (!response.IsSuccess)
                throw new Exception("Request failed with status code.");

            string contentType = response.Headers["Content-Type"];
            if (!string.Equals(contentType, expectedMime, StringComparison.OrdinalIgnoreCase))
                throw new Exception($"Unexpected content type: {contentType}");

            byte[] data = response.Content.ReadAsByteArray();
            System.IO.File.WriteAllBytes(outputPath, data);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}