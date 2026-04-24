// Log errors encountered during resource download to a dedicated error log file.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class LogMessageHandler : MessageHandler
{
    public static List<string> Errors = new List<string>();

    public override void Invoke(INetworkOperationContext context)
    {
        if (context.Response.StatusCode != HttpStatusCode.OK)
        {
            Errors.Add(string.Format("Error downloading {0}", context.Request.RequestUri));
        }
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Configuration configuration = new Configuration();
            INetworkService service = configuration.GetService<INetworkService>();
            MessageHandlerCollection handlers = service.MessageHandlers;
            handlers.Insert(0, new LogMessageHandler());

            string url = "https://example.com";
            HTMLDocument document = new HTMLDocument(url, configuration);
            document.Save("output.html");

            if (LogMessageHandler.Errors.Count > 0)
            {
                File.WriteAllLines("error.log", LogMessageHandler.Errors);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
    }
}