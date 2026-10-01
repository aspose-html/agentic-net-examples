// Create a Configuration, add a one‑second TimeoutMessageHandler, and load an HTML file.

public sealed class OneSecondTimeoutMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Timeout = System.TimeSpan.FromSeconds(1);
        Next(context);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new OneSecondTimeoutMessageHandler());

            string htmlFilePath = "sample.html";
            if (!System.IO.File.Exists(htmlFilePath))
            {
                System.IO.File.WriteAllText(htmlFilePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFilePath, configuration))
            {
                System.Console.WriteLine("Document title: " + document.Title);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}