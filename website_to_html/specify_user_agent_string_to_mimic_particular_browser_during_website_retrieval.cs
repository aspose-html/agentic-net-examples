// Specify a user-agent string to mimic a particular browser during website retrieval.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

namespace UserAgentExample
{
    class Program
    {
        // Custom message handler to set the User-Agent header
        class UserAgentHandler : MessageHandler
        {
            private readonly string _userAgent;

            public UserAgentHandler(string userAgent)
            {
                _userAgent = userAgent;
            }

            public override void Invoke(INetworkOperationContext context)
            {
                context.Request.Headers["User-Agent"] = _userAgent;
                Next(context);
            }
        }

        static void Main(string[] args)
        {
            try
            {
                // Target URL and desired User-Agent string
                string url = "https://example.com";
                string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0 Safari/537.36";

                // Create configuration and attach the custom handler
                Configuration configuration = new Configuration();
                INetworkService network = configuration.GetService<INetworkService>();
                network.MessageHandlers.Add(new UserAgentHandler(userAgent));

                // Load the document using the configuration with the custom User-Agent
                using (HTMLDocument document = new HTMLDocument(url, string.Empty, configuration))
                {
                    // Retrieve the full HTML markup
                    string html = document.DocumentElement.OuterHTML;
                    Console.WriteLine(html);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}