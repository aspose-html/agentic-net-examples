// Create a document, add a meta refresh tag with 5‑second delay, and test automatic reload.

using System;
using System.IO;
using System.Text;
using System.Threading;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare initial HTML content
            string initialHtml = "<!DOCTYPE html><html><head></head><body></body></html>";
            byte[] htmlBytes = Encoding.UTF8.GetBytes(initialHtml);
            string outputPath = "output.html";

            // Create document from in‑memory HTML and add meta refresh tag
            using (var inputStream = new MemoryStream(htmlBytes))
            using (HTMLDocument document = new HTMLDocument(inputStream, "about:blank"))
            {
                // Get the <head> element
                Element headElement = document.GetElementsByTagName("head")[0];
                HTMLElement head = (HTMLElement)headElement;

                // Create <meta http-equiv="refresh" content="5;url=https://example.com">
                HTMLElement meta = (HTMLElement)document.CreateElement("meta");
                meta.SetAttribute("http-equiv", "refresh");
                meta.SetAttribute("content", "5;url=https://example.com");
                head.AppendChild(meta);

                // Save the modified document
                document.Save(outputPath);
            }

            // Load the saved document and wait for it to finish loading
            using (AutoResetEvent resetEvent = new AutoResetEvent(false))
            {
                string loadedText = string.Empty;
                using (HTMLDocument loadedDoc = new HTMLDocument())
                {
                    loadedDoc.OnReadyStateChange += (sender, e) =>
                    {
                        if (loadedDoc.ReadyState == "complete")
                        {
                            loadedText = loadedDoc.DocumentElement != null ? loadedDoc.DocumentElement.TextContent : string.Empty;
                            resetEvent.Set();
                        }
                    };

                    // Navigate to the saved file (file URI)
                    string fileUri = new Uri(Path.GetFullPath(outputPath)).AbsoluteUri;
                    loadedDoc.Navigate(fileUri);

                    // Wait up to 10 seconds for loading to complete
                    resetEvent.WaitOne(10000);
                }

                Console.WriteLine("Loaded document text content:");
                Console.WriteLine(loadedText);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}