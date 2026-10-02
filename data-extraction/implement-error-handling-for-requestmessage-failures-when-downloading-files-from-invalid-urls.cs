// Implement error handling for RequestMessage failures when downloading files from invalid URLs.

using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Aspose.Html.HTMLDocument document = null;
        try
        {
            document = new Aspose.Html.HTMLDocument();

            // Invalid URL example
            Aspose.Html.Url url = new Aspose.Html.Url("http://invalid.example.com/nonexistent.html");
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

            if (response.IsSuccess)
            {
                System.Console.WriteLine("Download succeeded.");
                byte[] contentBytes = response.Content.ReadAsByteArray();
                System.Console.WriteLine($"Content length: {contentBytes.Length} bytes.");
            }
            else
            {
                System.Console.WriteLine($"Failed to download. Status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Exception: {ex.Message}");
        }
        finally
        {
            if (document != null)
            {
                document.Dispose();
            }
        }
    }
}