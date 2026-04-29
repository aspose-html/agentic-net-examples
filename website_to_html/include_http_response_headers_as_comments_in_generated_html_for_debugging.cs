// Include HTTP response headers as comments within the generated HTML for debugging.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class HeaderCaptureHandler : MessageHandler
{
    public static List<string> CapturedHeaders = new List<string>();

    public override void Invoke(INetworkOperationContext context)
    {
        Next(context);
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
            // Create configuration and register the custom message handler
            Configuration configuration = new Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Add(new HeaderCaptureHandler());

            // Load the HTML document from the specified URL
            string url = "https://example.com";
            using (HTMLDocument document = new HTMLDocument(url, configuration))
            {
                // Insert captured HTTP response headers as an HTML comment
                if (HeaderCaptureHandler.CapturedHeaders.Count > 0)
                {
                    string commentText = "\n" + string.Join("\n", HeaderCaptureHandler.CapturedHeaders) + "\n";
                    var commentNode = document.CreateComment(commentText);
                    document.InsertBefore(commentNode, document.DocumentElement);
                }

                // Save the resulting HTML document
                document.Save("output.html");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}