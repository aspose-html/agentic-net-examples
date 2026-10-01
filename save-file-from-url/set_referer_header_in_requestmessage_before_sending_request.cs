// Set the Referer header in RequestMessage before sending the request.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class RefererHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Headers["Referer"] = "https://example.com/";
        Next(context);
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
            networkService.MessageHandlers.Add(new RefererHandler());

            string url = "https://www.example.com/";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine("Document saved to: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}