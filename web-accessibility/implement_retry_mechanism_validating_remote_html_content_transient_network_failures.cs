// Implement a retry mechanism when validating remote HTML content that may experience transient network failures.

namespace AsposeHtmlRetryExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // Create configuration
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

                // Get network service and add retry handler
                Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
                network.MessageHandlers.Add(new RetryMessageHandler(3));

                // Load remote HTML document with retry mechanism
                string url = "https://example.com";
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
                {
                    string html = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
                    System.Console.WriteLine(html);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    public class RetryMessageHandler : Aspose.Html.Net.MessageHandler
    {
        private readonly int _maxRetries;

        public RetryMessageHandler(int maxRetries)
        {
            _maxRetries = maxRetries;
        }

        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            for (int attempt = 0; attempt <= _maxRetries; attempt++)
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