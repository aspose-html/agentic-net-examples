// Apply retry logic with exponential backoff for failed download attempts.

namespace AsposeHtmlRetryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
                network.MessageHandlers.Add(new RetryMessageHandler(3, 500));

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(configuration))
                {
                    Aspose.Html.Url url = new Aspose.Html.Url("https://example.com");
                    Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
                    Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

                    if (response.IsSuccess)
                    {
                        System.Byte[] contentBytes = response.Content.ReadAsByteArray();
                        System.Console.WriteLine("Downloaded {0} bytes.", contentBytes.Length);
                    }
                    else
                    {
                        System.Console.WriteLine("Failed to download. Status code: {0}", (int)response.StatusCode);
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    class RetryMessageHandler : Aspose.Html.Net.MessageHandler
    {
        private readonly int _maxRetries;
        private readonly int _baseDelayMs;

        public RetryMessageHandler(int maxRetries, int baseDelayMs)
        {
            _maxRetries = maxRetries;
            _baseDelayMs = baseDelayMs;
        }

        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            for (int attempt = 0; attempt <= _maxRetries; attempt++)
            {
                Next(context);
                int statusCode = (int)context.Response.StatusCode;
                if (statusCode < 500)
                {
                    break;
                }
                if (attempt < _maxRetries)
                {
                    int delay = _baseDelayMs * (int)System.Math.Pow(2, attempt);
                    System.Threading.Thread.Sleep(delay);
                }
            }
        }
    }
}