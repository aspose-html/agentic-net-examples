// Create a console application that accepts a URL argument and saves the downloaded file to the current directory.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string urlString = args.Length > 0 ? args[0] : "https://example.com";

            Aspose.Html.Url url = new Aspose.Html.Url(urlString);
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

            if (!response.IsSuccess)
                throw new Exception($"Failed to download. Status code: {response.StatusCode}");

            byte[] contentBytes = response.Content.ReadAsByteArray();

            Uri uri = new Uri(urlString);
            string fileName = System.IO.Path.GetFileName(uri.AbsolutePath);
            if (string.IsNullOrEmpty(fileName))
                fileName = "output.html";

            string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), fileName);
            System.IO.File.WriteAllBytes(outputPath, contentBytes);

            Console.WriteLine($"File saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}