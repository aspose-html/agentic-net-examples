// Generate a summary report that aggregates total errors across all processed HTML documents in a batch.

using System;
using System.IO;
using Aspose.Html.Net;

public class LogHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        if ((int)context.Response.StatusCode >= 400)
        {
            Program.ErrorCount++;
        }
        Console.WriteLine(context.Request.RequestUri + " | " + context.Response.StatusCode);
    }
}

public class Program
{
    public static int ErrorCount = 0;

    public static void Main()
    {
        try
        {
            string inputDir = "InputHtml";
            if (!Directory.Exists(inputDir))
                Directory.CreateDirectory(inputDir);

            if (Directory.GetFiles(inputDir, "*.html").Length == 0)
            {
                for (int i = 1; i <= 2; i++)
                {
                    string samplePath = Path.Combine(inputDir, $"sample{i}.html");
                    File.WriteAllText(samplePath, $"<html><body><h1>Sample {i}</h1></body></html>");
                }
            }

            foreach (string htmlPath in Directory.GetFiles(inputDir, "*.html"))
            {
                try
                {
                    Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                    Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
                    network.MessageHandlers.Add(new LogHandler());

                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                    {
                        string pdfPath = Path.ChangeExtension(htmlPath, ".pdf");
                        Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                    }
                }
                catch (Exception ex)
                {
                    ErrorCount++;
                    Console.WriteLine($"Error processing '{htmlPath}': {ex.Message}");
                }
            }

            Console.WriteLine($"Total errors across all documents: {ErrorCount}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Fatal error: {e.Message}");
        }
    }
}