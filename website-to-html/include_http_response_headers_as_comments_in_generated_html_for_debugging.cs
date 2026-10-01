// Include HTTP response headers as comments within the generated HTML for debugging.

using System;
using System.Collections.Generic;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html;

class HeaderCaptureHandler : Aspose.Html.Net.MessageHandler
{
    public static List<string> CapturedHeaders = new List<string>();

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        base.Next(context);
        foreach (object headerItem in context.Response.Headers)
        {
            if (headerItem != null)
            {
                CapturedHeaders.Add(headerItem.ToString());
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
            // Create configuration and attach the custom message handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new HeaderCaptureHandler());

            // URL to load
            string url = "https://example.com";

            // Load the document with the custom configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                // If any headers were captured, insert them as a comment at the top of the document
                if (HeaderCaptureHandler.CapturedHeaders.Count > 0)
                {
                    string commentText = "\n" + string.Join("\n", HeaderCaptureHandler.CapturedHeaders) + "\n";
                    var commentNode = document.CreateComment(commentText);
                    document.InsertBefore(commentNode, document.DocumentElement);
                }

                // Save the resulting HTML
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine($"Document saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}