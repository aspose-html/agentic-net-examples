// Create a document, add a meta refresh tag with 5‑second delay, and test automatic reload.

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
            // Create a basic HTML document
            string baseHtml = "<!DOCTYPE html><html><head></head><body>Test</body></html>";
            using (HTMLDocument document = new HTMLDocument(baseHtml, "about:blank"))
            {
                // Add meta refresh tag with 5‑second delay
                Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head")[0];
                Aspose.Html.Dom.Element meta = document.CreateElement("meta");
                meta.SetAttribute("http-equiv", "refresh");
                meta.SetAttribute("content", "5");
                head.AppendChild(meta);

                // Save the document to a temporary file
                string filePath = Path.Combine(Path.GetTempPath(), "meta_refresh.html");
                document.Save(filePath);

                // Test automatic reload
                using (AutoResetEvent resetEvent = new AutoResetEvent(false))
                using (HTMLDocument testDoc = new HTMLDocument())
                {
                    int loadCount = 0;
                    testDoc.OnReadyStateChange += (sender, e) =>
                    {
                        if (testDoc.ReadyState == "complete")
                        {
                            loadCount++;
                            Console.WriteLine($"Load #{loadCount} completed at {DateTime.Now}");
                            if (loadCount >= 2)
                                resetEvent.Set();
                        }
                    };

                    testDoc.Navigate(filePath);

                    // Wait for the second load (refresh) or timeout
                    if (!resetEvent.WaitOne(TimeSpan.FromSeconds(12)))
                    {
                        Console.WriteLine("Reload not detected within timeout.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}