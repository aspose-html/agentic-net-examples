// Perform asynchronous HTML document creation from a URL, and write the resulting content to a file.

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
            // URL to load asynchronously
            string url = "https://example.com";
            // Path where the captured HTML will be saved
            string outputPath = "output.html";

            // Synchronization event to wait for document loading completion
            using (AutoResetEvent resetEvent = new AutoResetEvent(false))
            // Create an empty HTMLDocument for asynchronous navigation
            using (HTMLDocument document = new HTMLDocument())
            {
                string htmlResult = string.Empty;

                // Subscribe to the ReadyStateChange event
                document.OnReadyStateChange += (sender, e) =>
                {
                    if (document.ReadyState == "complete")
                    {
                        // Capture the document's text content (or outer HTML as needed)
                        htmlResult = document.DocumentElement != null
                            ? document.DocumentElement.TextContent
                            : string.Empty;
                        resetEvent.Set();
                    }
                };

                // Start asynchronous navigation to the URL
                document.Navigate(url);
                // Wait until the document is fully loaded
                resetEvent.WaitOne();

                // Write the captured HTML content to a file
                File.WriteAllText(outputPath, htmlResult);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}