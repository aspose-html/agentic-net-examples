// Create a RequestMessage with custom headers and use it to download an image file from a URL.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string imageUrl = "https://example.com/sample.jpg";
            string outputPath = "downloaded_image.jpg";

            // Create a dummy HTMLDocument to access the network service
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
            {
                Aspose.Html.Url url = new Aspose.Html.Url(imageUrl);
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);

                // Add custom headers
                request.Headers["User-Agent"] = "AsposeHTMLExample";
                request.Headers["Accept"] = "image/*";

                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);
                if (response.IsSuccess)
                {
                    byte[] contentBytes = response.Content.ReadAsByteArray();
                    System.IO.File.WriteAllBytes(outputPath, contentBytes);
                    Console.WriteLine("Image downloaded successfully to " + outputPath);
                }
                else
                {
                    Console.WriteLine("Failed to download image. Status code: " + response.StatusCode);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}