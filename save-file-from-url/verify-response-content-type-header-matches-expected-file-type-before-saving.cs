// Verify the response Content-Type header matches the expected file type before saving.

using System;
using System.Collections.Generic;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html;

class CustomHandler : Aspose.Html.Net.MessageHandler
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
        if (options is Aspose.Html.Saving.PdfSaveOptions) return "application/pdf";
        if (options is Aspose.Html.Saving.DocSaveOptions) return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        if (options is Aspose.Html.Saving.XpsSaveOptions) return "application/vnd.ms-xpsdocument";
        return "application/octet-stream";
    }

    static void Main()
    {
        try
        {
            string url = "https://example.com";
            string outputPath = "output.pdf";

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new CustomHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                string expectedMime = GetMimeTypeForDocumentOptions(new Aspose.Html.Saving.PdfSaveOptions());
                string actualMime = null;
                foreach (string header in CustomHandler.capturedHeaders)
                {
                    if (header.StartsWith("Content-Type:", StringComparison.OrdinalIgnoreCase))
                    {
                        actualMime = header.Substring("Content-Type:".Length).Trim();
                        break;
                    }
                }

                if (actualMime == null)
                {
                    System.Console.WriteLine("Content-Type header not found.");
                }
                else if (!actualMime.Equals(expectedMime, StringComparison.OrdinalIgnoreCase))
                {
                    System.Console.WriteLine($"Warning: Expected MIME '{expectedMime}' but got '{actualMime}'.");
                }

                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                System.Console.WriteLine("Conversion completed: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}