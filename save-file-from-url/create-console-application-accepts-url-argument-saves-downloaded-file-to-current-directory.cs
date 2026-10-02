// Create a console application that accepts a URL argument and saves the downloaded file to the current directory.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string urlString = args.Length > 0 ? args[0] : "https://example.com";
            var url = new Aspose.Html.Url(urlString);
            var document = new Aspose.Html.HTMLDocument();
            var request = new Aspose.Html.Net.RequestMessage(url);
            var response = document.Context.Network.Send(request);

            if (!response.IsSuccess)
                throw new Exception($"Failed to download. Status code: {response.StatusCode}");

            byte[] contentBytes = response.Content.ReadAsByteArray();

            string fileName;
            try
            {
                var uri = new Uri(urlString);
                fileName = Path.GetFileName(uri.LocalPath);
                if (string.IsNullOrEmpty(fileName))
                    fileName = "index.html";
            }
            catch
            {
                fileName = "downloaded.html";
            }

            string outputPath = Path.Combine(Environment.CurrentDirectory, fileName);
            File.WriteAllBytes(outputPath, contentBytes);

            Console.WriteLine($"File saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}