// Log request processing start and end timestamps with a timestamping handler.

using System;

public sealed class TimestampHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        System.DateTime startTime = System.DateTime.UtcNow;
        this.Next(context);
        System.DateTime endTime = System.DateTime.UtcNow;
        System.TimeSpan elapsed = endTime - startTime;
        System.Diagnostics.Debug.WriteLine("Request: " + context.Request.RequestUri);
        System.Diagnostics.Debug.WriteLine("Start: " + startTime.ToString("O"));
        System.Diagnostics.Debug.WriteLine("End: " + endTime.ToString("O"));
        System.Diagnostics.Debug.WriteLine("Elapsed: " + elapsed.TotalMilliseconds + " ms");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello Aspose.HTML</h1></body></html>";
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new TimestampHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, configuration))
            {
                Console.WriteLine("HTML document loaded successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}