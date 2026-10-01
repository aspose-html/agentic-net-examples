// Configure user agent string, request a web page, and capture the final rendered HTML source.

using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            // 1. Create an HTML document from a string literal and get its outer HTML.
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            using (Aspose.Html.HTMLDocument documentFromString = new Aspose.Html.HTMLDocument(htmlContent))
            {
                string outerHtml = ((Aspose.Html.HTMLElement)documentFromString.DocumentElement).OuterHTML;
                Console.WriteLine("OuterHTML from string document:");
                Console.WriteLine(outerHtml);
            }

            // 2. Navigate to a URL and wait for the document to be fully loaded.
            string url = "https://example.com";
            using (System.Threading.AutoResetEvent resetEvent = new System.Threading.AutoResetEvent(false))
            using (Aspose.Html.HTMLDocument navigatingDocument = new Aspose.Html.HTMLDocument())
            {
                string htmlResult = string.Empty;
                navigatingDocument.OnReadyStateChange += (sender, e) =>
                {
                    if (navigatingDocument.ReadyState == "complete")
                    {
                        htmlResult = navigatingDocument.DocumentElement != null
                            ? navigatingDocument.DocumentElement.TextContent
                            : string.Empty;
                        resetEvent.Set();
                    }
                };
                navigatingDocument.Navigate(url);
                // Wait up to 15 seconds to avoid indefinite blocking.
                if (!resetEvent.WaitOne(TimeSpan.FromSeconds(15)))
                {
                    Console.WriteLine("Timeout while waiting for navigation to complete.");
                }
                else
                {
                    Console.WriteLine("Text content after navigation:");
                    Console.WriteLine(htmlResult);
                }
            }

            // 3. Convert HTML string to MHTML and save to a file.
            string baseUrl = "https://example.com";
            Aspose.Html.Saving.MHTMLSaveOptions mhtmlOptions = new Aspose.Html.Saving.MHTMLSaveOptions();
            string mhtmlOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.mhtml");
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUrl, mhtmlOptions, mhtmlOutputPath);
            Console.WriteLine($"MHTML saved to: {mhtmlOutputPath}");

            // 4. Save an HTML document to a file with custom resource handling options.
            string htmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            File.WriteAllText(htmlFilePath, htmlContent);
            using (Aspose.Html.HTMLDocument fileDocument = new Aspose.Html.HTMLDocument(htmlFilePath))
            {
                Aspose.Html.Saving.HTMLSaveOptions htmlSaveOptions = new Aspose.Html.Saving.HTMLSaveOptions();
                htmlSaveOptions.ResourceHandlingOptions.MaxHandlingDepth = 5;
                string htmlOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
                fileDocument.Save(htmlOutputPath, htmlSaveOptions);
                Console.WriteLine($"HTML saved to: {htmlOutputPath}");
            }

            // 5. Load a document via a request message with a timeout and get its outer HTML.
            string requestUrl = "https://example.com";
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(requestUrl);
            request.Timeout = System.TimeSpan.FromSeconds(10);
            using (Aspose.Html.HTMLDocument requestDocument = new Aspose.Html.HTMLDocument(request))
            {
                string outerHtmlFromRequest = ((Aspose.Html.HTMLElement)requestDocument.DocumentElement).OuterHTML;
                Console.WriteLine("OuterHTML from request document:");
                Console.WriteLine(outerHtmlFromRequest);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}