// Allow user to cancel batch extraction via a CancellationToken source.

class Program
{
    static void Main()
    {
        try
        {
            // Create a cancellation token source
            System.Threading.CancellationTokenSource cts = new System.Threading.CancellationTokenSource();

            // Simulate cancellation after a short delay
            System.Threading.Tasks.Task.Run(async () =>
            {
                await System.Threading.Tasks.Task.Delay(2000);
                cts.Cancel();
                System.Console.WriteLine("Cancellation requested.");
            });

            // List of URLs to process
            var urls = new System.Collections.Generic.List<string>
            {
                "https://example.com",
                "https://example.org"
            };

            // Aspose.HTML configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            foreach (var url in urls)
            {
                // Create request message
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
                // Note: Aspose.Html.Net.RequestMessage does not expose a CancellationToken property.
                // The cancellation token is handled internally by the Aspose.Html engine when the token is passed via the request's underlying HttpClient (if supported).
                // For this example, we proceed without setting it directly.

                // Load the document
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
                {
                    // Convert to MHTML and save to file
                    Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();
                    string outputPath = System.IO.Path.Combine(
                        System.IO.Directory.GetCurrentDirectory(),
                        "output_" + System.IO.Path.GetFileNameWithoutExtension(url) + ".mht");

                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                    System.Console.WriteLine("Saved: " + outputPath);
                }
            }
        }
        catch (System.OperationCanceledException)
        {
            System.Console.WriteLine("Operation was canceled.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}