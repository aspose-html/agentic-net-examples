// Perform asynchronous HTML document creation from a URL, and write the resulting content to a file.

using System;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            string outputPath = "output.html";

            using (AutoResetEvent resetEvent = new AutoResetEvent(false))
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
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

                document.Save(outputPath);
                Console.WriteLine("HTML content saved to: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}