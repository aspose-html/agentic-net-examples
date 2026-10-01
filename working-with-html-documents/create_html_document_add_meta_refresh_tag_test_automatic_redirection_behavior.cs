// Create an HTML document, add a meta refresh tag, and test automatic redirection behavior.

using System;
using System.IO;
using System.Text;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            // Example 1: Navigate to a URL and get page text when loading is complete
            string url = "https://example.com";
            using (AutoResetEvent resetEvent = new AutoResetEvent(false))
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
                // Wait up to 10 seconds for the page to load
                if (!resetEvent.WaitOne(TimeSpan.FromSeconds(10)))
                {
                    Console.WriteLine("Timeout while waiting for page to load.");
                }
                else
                {
                    Console.WriteLine("Page text content:");
                    Console.WriteLine(htmlResult);
                }
            }

            // Example 2: Load HTML from a string, modify a meta tag, and save to a file
            string htmlContent = "<html><head><meta name=\"description\" content=\"old\"></head><body>Hello World</body></html>";
            byte[] bytes = Encoding.UTF8.GetBytes(htmlContent);
            using (var inputStream = new MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, ""))
            {
                var metaElements = document.GetElementsByTagName("meta");
                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    if (meta.GetAttribute("name") == "description")
                    {
                        meta.SetAttribute("content", "new description");
                    }
                }

                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine($"Modified HTML saved to \"{outputPath}\".");
            }

            // Example 3: Demonstrate OnLoad event and retrieve outer HTML
            using (AutoResetEvent loadEvent = new AutoResetEvent(false))
            using (Aspose.Html.HTMLDocument docLoad = new Aspose.Html.HTMLDocument())
            {
                string outerHTML = string.Empty;
                docLoad.OnLoad += (sender, e) =>
                {
                    outerHTML = docLoad.DocumentElement?.OuterHTML ?? string.Empty;
                    loadEvent.Set();
                };

                docLoad.Navigate(url);
                if (!loadEvent.WaitOne(TimeSpan.FromSeconds(10)))
                {
                    Console.WriteLine("Timeout while waiting for OnLoad event.");
                }
                else
                {
                    Console.WriteLine("Outer HTML of loaded document:");
                    Console.WriteLine(outerHTML);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}