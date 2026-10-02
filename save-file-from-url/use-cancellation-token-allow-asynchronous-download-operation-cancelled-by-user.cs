// Use a cancellation token to allow the asynchronous download operation to be cancelled by the user.

using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            using (CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(5)))
            {
                CancellationToken token = cts.Token;

                Task<byte[]> downloadTask = Task.Run(() =>
                {
                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
                    {
                        Aspose.Html.Url aspUrl = new Aspose.Html.Url(url);
                        Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(aspUrl);
                        Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);
                        if (response.IsSuccess)
                        {
                            byte[] contentBytes = response.Content.ReadAsByteArray();
                            return contentBytes;
                        }
                        else
                        {
                            throw new Exception($"Request failed with status code {response.StatusCode}");
                        }
                    }
                }, token);

                byte[] result = downloadTask.GetAwaiter().GetResult();
                Console.WriteLine($"Downloaded {result.Length} bytes.");
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Download was cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}