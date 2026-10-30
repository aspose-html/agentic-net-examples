// Implement error handling for RequestMessage failures when downloading files from invalid URLs.

using System;

class Program
{
    static void Main()
    {
        try
        {
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
            {
                Aspose.Html.Url url = new Aspose.Html.Url("http://invalid.example.com/nonexistent.html");
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);
                if (response.IsSuccess)
                {
                    byte[] contentBytes = response.Content.ReadAsByteArray();
                    System.Console.WriteLine($"Downloaded {contentBytes.Length} bytes from {url}.");
                }
                else
                {
                    System.Console.WriteLine($"Failed to download URL: {url}. Status: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Exception occurred: {ex.Message}");
        }
    }
}