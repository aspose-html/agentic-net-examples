// Create a Configuration, add a one‑second TimeoutMessageHandler, and load an HTML file.

using System;

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
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get network service and add timeout handler
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new OneSecondTimeoutMessageHandler());

            // Prepare sample HTML file
            string dataDir = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Data");
            System.IO.Directory.CreateDirectory(dataDir);
            string htmlPath = System.IO.Path.Combine(dataDir, "sample.html");
            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>");
            }

            // Load HTML document with configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration);
            System.Console.WriteLine("Document title: " + document.Title);
            document.Dispose();
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}