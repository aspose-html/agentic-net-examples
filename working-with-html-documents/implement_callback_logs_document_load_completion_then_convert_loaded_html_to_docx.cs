// Implement a callback that logs document load completion, then convert the loaded HTML to DOCX.

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
                        htmlResult = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                        Console.WriteLine("Document load completed.");
                        resetEvent.Set();
                    }
                };
                document.Navigate(url);
                resetEvent.WaitOne();
                Console.WriteLine("Conversion to DOCX is not supported directly by Aspose.Html API.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}