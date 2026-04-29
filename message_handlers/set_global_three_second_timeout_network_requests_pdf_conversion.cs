// Set a global three‑second timeout for all network requests during PDF conversion.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

public sealed class ThreeSecondTimeoutHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        context.Request.Timeout = TimeSpan.FromSeconds(3);
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Configuration configuration = new Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Insert(0, new ThreeSecondTimeoutHandler());

            string inputPath = "input.html";
            string outputPath = "output.pdf";

            Converter.ConvertHTML(inputPath, configuration, new PdfSaveOptions(), outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}