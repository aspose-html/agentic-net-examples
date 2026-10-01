// Add a TimeoutMessageHandler with a five‑second limit to ensure large image downloads do not stall conversion.

using System;
using System.IO;

public sealed class TimeoutMessageHandler : Aspose.Html.Net.MessageHandler
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
            string htmlContent = "<html><body><img src='https://example.com/large-image.jpg' /></body></html>";

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new TimeoutMessageHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, configuration))
            {
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.png");
                Aspose.Html.Converters.Converter.ConvertHTML(document, new Aspose.Html.Saving.ImageSaveOptions(), outputPath);
                Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}