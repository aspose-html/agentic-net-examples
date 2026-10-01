// Use a cancellation token to allow the asynchronous download operation to be cancelled by the user.

namespace Example
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            try
            {
                string urlString = "https://example.com";
                string outputPath = "downloaded.html";

                using (System.Threading.CancellationTokenSource cts = new System.Threading.CancellationTokenSource())
                {
                    cts.CancelAfter(System.TimeSpan.FromSeconds(5));

                    await System.Threading.Tasks.Task.Run(() =>
                    {
                        cts.Token.ThrowIfCancellationRequested();

                        using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
                        {
                            Aspose.Html.Url url = new Aspose.Html.Url(urlString);
                            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
                            Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);
                            if (!response.IsSuccess)
                            {
                                throw new System.Exception($"Request failed with status code {response.StatusCode}");
                            }

                            byte[] contentBytes = response.Content.ReadAsByteArray();
                            System.IO.File.WriteAllBytes(outputPath, contentBytes);
                        }
                    }, cts.Token);
                }

                System.Console.WriteLine("Download completed successfully.");
            }
            catch (System.OperationCanceledException)
            {
                System.Console.WriteLine("Download was cancelled.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}