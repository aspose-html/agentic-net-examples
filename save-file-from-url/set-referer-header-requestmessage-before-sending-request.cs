// Set the Referer header in RequestMessage before sending the request.

using System;

class Program
{
    static void Main()
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();
            var networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new RefererHeaderHandler());

            string url = "https://www.example.org/";
            using (var document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine($"Document saved to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

class RefererHeaderHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Headers["Referer"] = "https://example.com/";
        Next(context);
    }
}