// Verify the HTTP response status code equals 200 before processing.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class StatusCodeHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        if (context.Response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new System.Exception($"HTTP request failed with status code {(int)context.Response.StatusCode}");
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new StatusCodeHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                Aspose.Html.HTMLElement titleElement = document.GetElementsByTagName("title")[0] as Aspose.Html.HTMLElement;
                if (titleElement != null)
                {
                    System.Console.WriteLine("Title: " + titleElement.TextContent);
                }
                else
                {
                    System.Console.WriteLine("Title element not found.");
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}