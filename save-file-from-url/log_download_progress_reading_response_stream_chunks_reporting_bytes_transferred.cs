// Log the download progress by reading the response stream in chunks and reporting bytes transferred.

namespace AsposeHtmlDownloadProgress
{
    class Program
    {
        static void Main()
        {
            try
            {
                var url = new Aspose.Html.Url("https://example.com");
                var request = new Aspose.Html.Net.RequestMessage(url);
                using (var tempDoc = new Aspose.Html.HTMLDocument())
                {
                    var response = tempDoc.Context.Network.Send(request);
                    if (!response.IsSuccess)
                    {
                        System.Console.WriteLine($"Request failed with status: {response.StatusCode}");
                        return;
                    }

                    var contentBytes = response.Content.ReadAsByteArray();

                    using (var ms = new System.IO.MemoryStream(contentBytes))
                    {
                        const int bufferSize = 8192;
                        var buffer = new byte[bufferSize];
                        int bytesRead;
                        long totalBytes = 0;
                        while ((bytesRead = ms.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            totalBytes += bytesRead;
                            System.Console.WriteLine($"Downloaded {totalBytes} bytes");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}