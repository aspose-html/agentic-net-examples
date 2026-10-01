// Configure network timeout values in a Configuration object and apply to all message handlers.

using System;

public sealed class TimeoutHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Timeout = System.TimeSpan.FromSeconds(5);
        Next(context);
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
            networkService.MessageHandlers.Add(new TimeoutHandler());

            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            string outputPath = "output.pdf";

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, configuration, new Aspose.Html.Saving.PdfSaveOptions(), outputPath);

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}