// Create a batch process that applies TimeoutMessageHandler to each HTML document in a directory.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

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
            string inputDir = "InputHtml";
            Directory.CreateDirectory(inputDir);

            // Create a sample HTML file if the directory is empty
            if (Directory.GetFiles(inputDir, "*.html").Length == 0)
            {
                string samplePath = Path.Combine(inputDir, "sample.html");
                File.WriteAllText(samplePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            foreach (string htmlPath in Directory.GetFiles(inputDir, "*.html"))
            {
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
                networkService.MessageHandlers.Add(new TimeoutMessageHandler());

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                {
                    string pdfPath = Path.ChangeExtension(htmlPath, ".pdf");
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                    Console.WriteLine($"Converted '{htmlPath}' to '{pdfPath}'.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}