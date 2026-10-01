// Perform asynchronous HTML document creation from a URL, and write the resulting content to a file.

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
            // Create a simple HTML document, add text, and save it.
            string outputPath1 = "output.html";
            var doc = new Aspose.Html.HTMLDocument();
            Aspose.Html.Dom.Text txt = doc.CreateTextNode("Hello, Aspose.HTML!");
            doc.Body.AppendChild(txt);
            doc.Save(outputPath1);
            Console.WriteLine($"Document saved to {outputPath1}");

            // Load HTML from a memory stream, modify a meta tag, and save.
            string htmlContent = "<html><head><meta name='author' content='old'></head><body></body></html>";
            byte[] bytes = Encoding.UTF8.GetBytes(htmlContent);
            using (var inputStream = new MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, ""))
            {
                var metaElements = document.GetElementsByTagName("meta");
                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    if (meta.GetAttribute("name") == "author")
                    {
                        meta.SetAttribute("content", "new author");
                    }
                }
                string outputPath2 = "modified.html";
                document.Save(outputPath2);
                Console.WriteLine($"Modified document saved to {outputPath2}");
            }

            // Navigate to a URL, wait for loading to complete, and print the text content.
            string url = "https://example.com";
            using (var resetEvent = new AutoResetEvent(false))
            using (var document = new Aspose.Html.HTMLDocument())
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

                // Wait up to 10 seconds for the navigation to complete.
                if (resetEvent.WaitOne(TimeSpan.FromSeconds(10)))
                {
                    Console.WriteLine("Page content:");
                    Console.WriteLine(htmlResult);
                }
                else
                {
                    Console.WriteLine("Timeout waiting for page to load.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}