// Implement error handling that retries the download up to three times for transient network errors.

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string url = "https://example.com";
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
                networkService.MessageHandlers.Add(new RetryHandler(3));
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
                {
                    System.Console.WriteLine(document.Title);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    class RetryHandler : Aspose.Html.Net.MessageHandler
    {
        private readonly int maxRetries;
        public RetryHandler(int maxRetries)
        {
            this.maxRetries = maxRetries;
        }
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            for (int attempt = 0; attempt <= this.maxRetries; attempt++)
            {
                Next(context);
                if ((int)context.Response.StatusCode < 500)
                {
                    break;
                }
            }
        }
    }
}