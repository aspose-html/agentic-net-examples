// Use a retry‑after header from HTTP response to schedule delayed retries for rate‑limited resources.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
                network.MessageHandlers.Add(new RetryAfterHandler(3));

                string url = "https://example.com/rate-limited-resource";
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
                {
                    string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                    System.Console.WriteLine(html);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    class RetryAfterHandler : Aspose.Html.Net.MessageHandler
    {
        private readonly int _maxRetries;
        public RetryAfterHandler(int maxRetries)
        {
            _maxRetries = maxRetries;
        }

        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            for (int attempt = 0; attempt <= _maxRetries; attempt++)
            {
                Next(context);
                int status = (int)context.Response.StatusCode;
                if (status != 429)
                {
                    break;
                }

                string retryAfter = null;
                try
                {
                    retryAfter = context.Response.Headers["Retry-After"];
                }
                catch { }

                int delaySeconds = 5;
                if (!string.IsNullOrEmpty(retryAfter) && int.TryParse(retryAfter, out int secs))
                {
                    delaySeconds = secs;
                }

                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(delaySeconds));
            }
        }
    }
}