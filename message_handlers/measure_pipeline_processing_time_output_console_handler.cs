// Measure total pipeline processing time and output to console using a timing handler.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Saving;

public class TimingHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
        Next(context);
        stopwatch.Stop();
        System.Diagnostics.Debug.WriteLine("Request: " + context.Request.RequestUri);
        System.Diagnostics.Debug.WriteLine("Time: " + stopwatch.ElapsedMilliseconds + "ms");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string pdfPath = "output.pdf";

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new TimingHandler());

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration);

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            System.Diagnostics.Stopwatch totalTimer = System.Diagnostics.Stopwatch.StartNew();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
            totalTimer.Stop();

            Console.WriteLine("Total pipeline processing time: " + totalTimer.ElapsedMilliseconds + " ms");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}