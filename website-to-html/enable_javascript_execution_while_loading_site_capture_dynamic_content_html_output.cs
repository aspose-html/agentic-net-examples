// Enable JavaScript execution while loading the site to capture dynamic content in the HTML output.

using System;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content loaded via a data URL to avoid external network calls
            string url = "data:text/html,<html><body>Hello World</body></html>";

            using (System.Threading.AutoResetEvent resetEvent = new System.Threading.AutoResetEvent(false))
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
            {
                string htmlResult = string.Empty;

                document.OnReadyStateChange += (sender, e) =>
                {
                    if (document.ReadyState == "complete")
                    {
                        htmlResult = document.DocumentElement != null
                            ? document.DocumentElement.TextContent
                            : string.Empty;
                        resetEvent.Set();
                    }
                };

                document.Navigate(url);
                // Wait up to 10 seconds for the navigation to complete
                resetEvent.WaitOne(TimeSpan.FromSeconds(10));

                Console.WriteLine(htmlResult);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}