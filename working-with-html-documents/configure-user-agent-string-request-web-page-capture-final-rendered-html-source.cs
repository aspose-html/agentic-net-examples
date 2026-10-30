// Configure user agent string, request a web page, and capture the final rendered HTML source.

using System;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            request.Headers["User-Agent"] = "MyCustomUserAgent/1.0";

            using (AutoResetEvent resetEvent = new AutoResetEvent(false))
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request))
            {
                string htmlResult = string.Empty;

                document.OnReadyStateChange += (sender, e) =>
                {
                    if (document.ReadyState == "complete")
                    {
                        htmlResult = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
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
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}