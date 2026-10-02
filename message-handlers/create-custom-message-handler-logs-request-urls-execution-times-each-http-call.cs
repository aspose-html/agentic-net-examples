// Create a custom message handler that logs request URLs and execution times for each HTTP call.

public sealed class TimeLoggerMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        System.DateTime startTime = System.DateTime.UtcNow;
        System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
        Next(context);
        stopwatch.Stop();
        System.DateTime endTime = System.DateTime.UtcNow;
        System.TimeSpan elapsed = endTime - startTime;
        System.Diagnostics.Debug.WriteLine("Request: " + context.Request.RequestUri);
        System.Diagnostics.Debug.WriteLine("Start: " + startTime.ToString("O"));
        System.Diagnostics.Debug.WriteLine("End: " + endTime.ToString("O"));
        System.Diagnostics.Debug.WriteLine("Elapsed: " + elapsed.TotalMilliseconds + " ms");
        System.Console.WriteLine($"Request: {context.Request.RequestUri}");
        System.Console.WriteLine($"Elapsed: {elapsed.TotalMilliseconds} ms");
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new TimeLoggerMessageHandler());

            string inputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.html");
            System.IO.File.WriteAllText(inputPath, "<html><body><h1>Hello</h1></body></html>");

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration))
            {
                System.Console.WriteLine("HTML document loaded successfully.");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}