// Verify the response Content-Type header matches the expected file type before saving.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;

class ResponseHeaderHandler : Aspose.Html.Net.MessageHandler
{
    public static List<string> capturedHeaders = new List<string>();
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        foreach (object headerItem in context.Response.Headers)
        {
            if (headerItem != null)
            {
                capturedHeaders.Add(headerItem.ToString());
            }
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Input URL and output file
            string url = "https://example.com/sample.pdf";
            string outputPath = Path.Combine(Path.GetTempPath(), "downloaded_sample.pdf");

            // Prepare configuration with custom message handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new ResponseHeaderHandler());

            // Create a temporary document to access the network context
            using (Aspose.Html.HTMLDocument tempDoc = new Aspose.Html.HTMLDocument())
            {
                // Build request and send it
                Aspose.Html.Url requestUrl = new Aspose.Html.Url(url);
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(requestUrl);
                Aspose.Html.Net.ResponseMessage response = tempDoc.Context.Network.Send(request);

                if (!response.IsSuccess)
                {
                    throw new Exception($"Request failed with status code {response.StatusCode}.");
                }

                // Read response content
                byte[] contentBytes = response.Content.ReadAsByteArray();

                // Determine expected MIME type for PDF output
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                string expectedMime = GetMimeTypeForDocumentOptions(pdfOptions);

                // Extract Content-Type header from captured headers
                string contentTypeHeader = null;
                foreach (string header in ResponseHeaderHandler.capturedHeaders)
                {
                    if (header.StartsWith("Content-Type:", StringComparison.OrdinalIgnoreCase))
                    {
                        contentTypeHeader = header.Substring("Content-Type:".Length).Trim();
                        break;
                    }
                }

                if (contentTypeHeader == null)
                {
                    throw new Exception("Content-Type header not found in response.");
                }

                // Verify that the response Content-Type matches the expected MIME type
                if (!contentTypeHeader.StartsWith(expectedMime, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception($"MIME type mismatch. Expected: {expectedMime}, Received: {contentTypeHeader}");
                }

                // Save the content to file
                System.IO.File.WriteAllBytes(outputPath, contentBytes);
                Console.WriteLine($"File saved successfully to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static string GetMimeTypeForDocumentOptions(object options)
    {
        if (options is Aspose.Html.Saving.PdfSaveOptions)
            return "application/pdf";
        if (options is Aspose.Html.Saving.DocSaveOptions)
            return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        if (options is Aspose.Html.Saving.XpsSaveOptions)
            return "application/vnd.ms-xpsdocument";
        return "application/octet-stream";
    }
}