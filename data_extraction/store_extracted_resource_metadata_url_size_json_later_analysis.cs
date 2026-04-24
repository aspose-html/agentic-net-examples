// Store extracted resource metadata such as URL and size in a JSON file for later analysis.

using System;
using System.IO;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();
            Aspose.Html.Url url = new Aspose.Html.Url("https://example.com");
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);
            bool isSuccess = response.IsSuccess;
            if (!isSuccess)
            {
                Console.WriteLine("Failed to download the resource.");
                return;
            }

            byte[] contentBytes = response.Content.ReadAsByteArray();

            var metadata = new
            {
                Url = url.ToString(),
                SizeInBytes = contentBytes.Length
            };

            string json = JsonSerializer.Serialize(metadata, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("resource_metadata.json", json);

            Console.WriteLine("Metadata saved to resource_metadata.json");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}