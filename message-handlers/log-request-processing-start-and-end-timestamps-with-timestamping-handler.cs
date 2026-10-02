// Log request processing start and end timestamps with a timestamping handler.

public class Program
{
    public static void Main()
    {
        try
        {
            // Create configuration and add the timestamp logging handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new TimestampLoggingHandler());

            // Prepare a minimal HTML file
            string dataDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Data");
            System.IO.Directory.CreateDirectory(dataDir);
            string htmlPath = System.IO.Path.Combine(dataDir, "sample.html");
            System.IO.File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello World</h1></body></html>");

            // Load the document (this triggers the handler)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // No additional processing required
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Timestamp logging handler that records start and end timestamps
public sealed class TimestampLoggingHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        System.DateTime startTime = System.DateTime.UtcNow;
        Next(context);
        System.DateTime endTime = System.DateTime.UtcNow;
        System.TimeSpan elapsed = endTime - startTime;

        System.Diagnostics.Debug.WriteLine("Request: " + context.Request.RequestUri);
        System.Diagnostics.Debug.WriteLine("Start: " + startTime.ToString("O"));
        System.Diagnostics.Debug.WriteLine("End: " + endTime.ToString("O"));
        System.Diagnostics.Debug.WriteLine("Elapsed: " + elapsed.TotalMilliseconds + " ms");
    }
}