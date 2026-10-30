// Add a TimeoutMessageHandler after logging handlers to ensure timeout enforcement occurs last.

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class LoggingMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        DateTime startTime = DateTime.UtcNow;
        Next(context);
        DateTime endTime = DateTime.UtcNow;
        TimeSpan elapsed = endTime - startTime;
        Debug.WriteLine("Request: " + context.Request.RequestUri);
        Debug.WriteLine("Start: " + startTime.ToString("O"));
        Debug.WriteLine("End: " + endTime.ToString("O"));
        Debug.WriteLine("Elapsed: " + elapsed.TotalMilliseconds + " ms");
    }
}

public sealed class TimeoutMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Timeout = TimeSpan.FromSeconds(30);
        Next(context);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string inputPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Configure Aspose.HTML
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add logging handler(s)
            networkService.MessageHandlers.Add(new LoggingMessageHandler());

            // Add timeout handler (must be last)
            networkService.MessageHandlers.Add(new TimeoutMessageHandler());

            // Load document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration))
            {
                // Save output
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine("Document saved to: " + Path.GetFullPath(outputPath));
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}