// Create a RequestMessage with custom headers and use it to download an image file from a URL.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string url = "https://example.com/image.jpg";
            string outputPath = "downloaded_image.jpg";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
            {
                Aspose.Html.Url requestUrl = new Aspose.Html.Url(url);
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(requestUrl);
                request.Headers.Add("User-Agent", "AsposeHTMLExample");
                request.Headers.Add("Accept", "image/*");

                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);
                if (response.IsSuccess)
                {
                    byte[] contentBytes = response.Content.ReadAsByteArray();
                    System.IO.File.WriteAllBytes(outputPath, contentBytes);
                    System.Console.WriteLine("Image downloaded successfully to " + outputPath);
                }
                else
                {
                    System.Console.WriteLine("Failed to download image.");
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}