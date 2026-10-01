// Measure total pipeline processing time and output to console using a timing handler.

public sealed class TimeLoggingHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        System.Diagnostics.Stopwatch requestTimer = System.Diagnostics.Stopwatch.StartNew();
        Next(context);
        requestTimer.Stop();
        System.Console.WriteLine("Request: " + context.Request.RequestUri + " | " + requestTimer.ElapsedMilliseconds + " ms");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputHtmlPath = "sample.html";
            string outputPdfPath = "output.pdf";

            if (!System.IO.File.Exists(inputHtmlPath))
            {
                System.IO.File.WriteAllText(inputHtmlPath, "<!DOCTYPE html><html><body><h1>Hello Aspose.HTML</h1></body></html>");
            }

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new TimeLoggingHandler());

            System.Diagnostics.Stopwatch conversionTimer = System.Diagnostics.Stopwatch.StartNew();

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtmlPath, configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
            {
                document.RenderTo(device);
            }

            conversionTimer.Stop();
            System.Console.WriteLine("Conversion completed in " + conversionTimer.Elapsed.TotalSeconds.ToString("F2") + " seconds.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}