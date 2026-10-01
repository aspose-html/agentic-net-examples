// Create a custom message handler that logs request URLs and execution times for each HTTP call.

public sealed class MyMessageHandler : Aspose.Html.Net.MessageHandler
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

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new MyMessageHandler());

            string tempDir = System.IO.Path.GetTempPath();
            string htmlPath = System.IO.Path.Combine(tempDir, "sample.html");
            System.IO.File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>");

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                string title = document.Title;
                System.Console.WriteLine("Document title: " + title);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}