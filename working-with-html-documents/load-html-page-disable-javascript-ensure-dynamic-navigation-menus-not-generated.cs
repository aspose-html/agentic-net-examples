// Load an HTML page, disable JavaScript, and ensure dynamic navigation menus are not generated.

using System;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";

            var configuration = new Aspose.Html.Configuration();
            configuration.Security = Aspose.Html.Sandbox.None;

            using (System.Threading.AutoResetEvent resetEvent = new System.Threading.AutoResetEvent(false))
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
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
            Console.WriteLine(ex.Message);
        }
    }
}