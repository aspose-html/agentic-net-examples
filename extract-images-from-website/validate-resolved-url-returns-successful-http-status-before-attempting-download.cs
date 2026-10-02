// Validate that each resolved URL returns a successful HTTP status before attempting download.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Dom;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlFilePath = Path.Combine(Path.GetTempPath(), "sample.html");
            string htmlContent = @"<html><body>" +
                                 @"<a href='https://www.example.com/'>Valid Link</a>" +
                                 @"<a href='https://nonexistent.example.invalid/'>Invalid Link</a>" +
                                 @"</body></html>";
            File.WriteAllText(htmlFilePath, htmlContent);

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(htmlFilePath))
            {
                // Ensure only local file resources are allowed (optional security handler)
                Configuration configuration = new Configuration();
                INetworkService networkService = configuration.GetService<INetworkService>();
                networkService.MessageHandlers.Insert(0, new LocalOnlyMessageHandler());

                // Output directory for downloaded resources
                string downloadDir = Path.Combine(Path.GetTempPath(), "downloaded_resources");
                Directory.CreateDirectory(downloadDir);

                foreach (Element linkElement in document.Links)
                {
                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    // Resolve the URL against the document's base URI
                    Url resolvedUrl = new Url(href, document.BaseURI);

                    // Send a HEAD request to validate the URL
                    RequestMessage request = new RequestMessage(resolvedUrl);
                    ResponseMessage response = document.Context.Network.Send(request);

                    if (!response.IsSuccess)
                    {
                        Console.WriteLine($"Link validation failed: {resolvedUrl} (Status: {(int)response.StatusCode})");
                        continue;
                    }

                    // Download the content
                    byte[] contentBytes = response.Content.ReadAsByteArray();

                    // Determine a safe file name
                    string fileName = Path.GetFileName(resolvedUrl.Pathname);
                    if (string.IsNullOrEmpty(fileName))
                        fileName = "downloaded_content_" + Guid.NewGuid().ToString() + ".bin";

                    string outputPath = Path.Combine(downloadDir, fileName);
                    File.WriteAllBytes(outputPath, contentBytes);
                    Console.WriteLine($"Successfully downloaded: {resolvedUrl} -> {outputPath}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // Message handler that allows only local file resources
    public sealed class LocalOnlyMessageHandler : Aspose.Html.Net.MessageHandler
    {
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            string requestUri = context.Request.RequestUri == null ? string.Empty : context.Request.RequestUri.ToString();
            if (!string.IsNullOrEmpty(requestUri) && !requestUri.StartsWith("file:", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("Only local file resources are allowed.");
            Next(context);
        }
    }
}