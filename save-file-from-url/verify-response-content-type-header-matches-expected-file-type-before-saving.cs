// Verify the response Content-Type header matches the expected file type before saving.

using System;
using System.Collections.Generic;
using System.IO;

class MyHandler : Aspose.Html.Net.MessageHandler
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
    static string GetMimeTypeForDocumentOptions(object options)
    {
        if (options is Aspose.Html.Saving.PdfSaveOptions)
            return "application/pdf";
        if (options is Aspose.Html.Saving.DocSaveOptions)
            return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        if (options is Aspose.Html.Saving.XpsSaveOptions)
            return "application/vnd.ms-xpsdocument";
        return string.Empty;
    }

    static void Main()
    {
        try
        {
            // Input URL and output file
            string url = "https://example.com/sample.html";
            string outputPath = Path.Combine(Path.GetTempPath(), "output.pdf");

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Configure network service with custom handler to capture headers
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new MyHandler());

            // Load HTML document from URL using the configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                // Verify Content-Type header matches expected MIME type for PDF
                string contentType = null;
                foreach (string header in MyHandler.capturedHeaders)
                {
                    if (header.StartsWith("Content-Type:", StringComparison.OrdinalIgnoreCase))
                    {
                        int colonIndex = header.IndexOf(':');
                        if (colonIndex >= 0 && colonIndex + 1 < header.Length)
                        {
                            contentType = header.Substring(colonIndex + 1).Trim();
                        }
                        break;
                    }
                }

                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                string expectedMime = GetMimeTypeForDocumentOptions(pdfOptions);

                if (!string.IsNullOrEmpty(contentType) && !string.Equals(contentType, expectedMime, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Warning: Content-Type header '{contentType}' does not match expected '{expectedMime}'.");
                }

                // Convert and save the document as PDF
                Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPath);
                Console.WriteLine($"Document saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}