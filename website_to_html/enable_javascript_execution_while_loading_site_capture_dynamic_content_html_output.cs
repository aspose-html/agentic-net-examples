// Enable JavaScript execution while loading the site to capture dynamic content in the HTML output.

using System;
using System.Threading;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";

            using (AutoResetEvent resetEvent = new AutoResetEvent(false))
            using (HTMLDocument document = new HTMLDocument())
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
                Console.WriteLine(htmlResult);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}