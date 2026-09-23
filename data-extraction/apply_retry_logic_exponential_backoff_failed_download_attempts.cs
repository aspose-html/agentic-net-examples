// Apply retry logic with exponential backoff for failed download attempts.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Configure Aspose.HTML with retry handler
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
                network.MessageHandlers.Add(new RetryMessageHandler(3));

                // URL to download
                string urlString = "https://example.com";
                Aspose.Html.Url url = new Aspose.Html.Url(urlString);
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
                request.Timeout = System.TimeSpan.FromSeconds(10);

                // Load document (download)
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request);
                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);
                bool isSuccess = response.IsSuccess;
                System.Console.WriteLine("Download success: " + isSuccess);
                System.Byte[] contentBytes = response.Content.ReadAsByteArray();
                System.Console.WriteLine("Content length: " + contentBytes.Length);

                // Prepare sample MHTML file
                string inputMhtmlPath = "sample.mhtml";
                string outputPdfPath = "output.pdf";
                if (!System.IO.File.Exists(inputMhtmlPath))
                {
                    System.IO.File.WriteAllText(inputMhtmlPath, "<html><body>Sample MHTML content</body></html>");
                }

                // Convert MHTML to PDF with retry
                ConvertMhtmlToPdfWithRetry(inputMhtmlPath, outputPdfPath, 3);
                System.Console.WriteLine("Conversion completed.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void ConvertMhtmlToPdfWithRetry(string inputPath, string outputPath, int maxAttempts)
        {
            System.Exception lastException = null;
            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                try
                {
                    using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
                    {
                        Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                        return;
                    }
                }
                catch (System.IO.IOException ioEx)
                {
                    lastException = ioEx;
                }
                catch (System.UnauthorizedAccessException uaEx)
                {
                    lastException = uaEx;
                }

                // Exponential backoff: 2^(attempt-1) seconds
                int delayMs = (int)System.Math.Pow(2, attempt - 1) * 1000;
                System.Threading.Thread.Sleep(delayMs);
            }

            if (lastException != null)
            {
                throw lastException;
            }
        }
    }

    // Message handler with exponential backoff for server errors
    class RetryMessageHandler : Aspose.Html.Net.MessageHandler
    {
        private readonly int maxRetries;
        public RetryMessageHandler(int maxRetries)
        {
            this.maxRetries = maxRetries;
        }

        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            for (int attempt = 0; attempt <= maxRetries; attempt++)
            {
                Next(context);
                int statusCode = (int)context.Response.StatusCode;
                if (statusCode < 500)
                {
                    // Success or client error, stop retrying
                    break;
                }

                // Server error, wait before next retry
                int delayMs = (int)System.Math.Pow(2, attempt) * 1000;
                System.Threading.Thread.Sleep(delayMs);
            }
        }
    }
}