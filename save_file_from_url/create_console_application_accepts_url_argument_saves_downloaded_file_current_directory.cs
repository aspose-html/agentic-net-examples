// Create a console application that accepts a URL argument and saves the downloaded file to the current directory.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length == 0)
                throw new ArgumentException("URL argument is required.");

            string urlString = args[0];

            // Download the file using Aspose.HTML network APIs
            HTMLDocument document = new HTMLDocument();
            Url url = new Url(urlString);
            RequestMessage request = new RequestMessage(url);
            ResponseMessage response = document.Context.Network.Send(request);

            if (!response.IsSuccess)
                throw new Exception($"Failed to download the resource. Status: {response.StatusCode}");

            byte[] contentBytes = response.Content.ReadAsByteArray();

            // Determine output file name
            string fileName = Path.GetFileName(new Uri(urlString).AbsolutePath);
            if (string.IsNullOrEmpty(fileName))
                fileName = "downloaded_file";

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            File.WriteAllBytes(outputPath, contentBytes);

            Console.WriteLine($"File saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}