// Create an HTML document, add a meta refresh tag, and test automatic redirection behavior.

using System;
using System.IO;
using System.Threading;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Create target page (page2.html)
            string page2Path = Path.Combine(Path.GetTempPath(), "page2.html");
            string page2Content = "<html><body><h1>Redirected Page</h1></body></html>";
            File.WriteAllText(page2Path, page2Content);

            // Create source page with meta refresh to page2.html
            string page1Path = Path.Combine(Path.GetTempPath(), "page1.html");
            string page1Content = $"<html><head><meta http-equiv=\"refresh\" content=\"0;url={page2Path}\"></head><body>Redirecting...</body></html>";
            File.WriteAllText(page1Path, page1Content);

            using (AutoResetEvent resetEvent = new AutoResetEvent(false))
            using (HTMLDocument document = new HTMLDocument())
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

                document.Navigate(page1Path);
                resetEvent.WaitOne();

                Console.WriteLine("Final document HTML after redirection:");
                Console.WriteLine(htmlResult);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}