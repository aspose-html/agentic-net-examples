// Verify the HTTP response status code equals 200 before processing.

using System;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new StatusCodeHandler());

            string url = "https://example.com";
            using (var document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                System.Console.WriteLine("Document title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            System.Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}

public class StatusCodeHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        if (context.Response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new InvalidOperationException($"HTTP request failed with status code {context.Response.StatusCode}");
        }
    }
}