// Enable JavaScript execution while loading the site to capture dynamic content in the HTML output.

using System;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";

            using (System.Threading.AutoResetEvent resetEvent = new System.Threading.AutoResetEvent(false))
            {
                // Configure the HTML engine and set a JavaScript timeout.
                var config = new Aspose.Html.Configuration();
                config.GetService<Aspose.Html.Services.IRuntimeService>().JavaScriptTimeout = TimeSpan.FromSeconds(30);

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(config))
                {
                    string htmlResult = string.Empty;

                    document.OnReadyStateChange += (sender, e) =>
                    {
                        if (document.ReadyState == "complete")
                        {
                            htmlResult = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                            resetEvent.Set();
                        }
                    };

                    document.Navigate(url);
                    resetEvent.WaitOne();

                    System.Console.WriteLine(htmlResult);
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}