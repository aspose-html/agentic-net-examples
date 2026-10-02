// Include HTTP response headers as comments within the generated HTML for debugging.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class HeaderCaptureHandler : Aspose.Html.Net.MessageHandler
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
    static void Main(string[] args)
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new HeaderCaptureHandler());

            string url = "https://example.com";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                if (HeaderCaptureHandler.capturedHeaders.Count > 0)
                {
                    string commentText = "\n" + string.Join("\n", HeaderCaptureHandler.capturedHeaders) + "\n";
                    var commentNode = document.CreateComment(commentText);
                    document.InsertBefore(commentNode, document.DocumentElement);
                }

                string outputPath = "output.html";
                document.Save(outputPath);
            }

            Console.WriteLine("HTML saved with headers as comments.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}