// Apply a cancellation token to the validation process to allow graceful termination during long batch runs.

using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Handler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        if (context.Response.StatusCode == HttpStatusCode.InternalServerError)
            return;
    }
}

class AuthHandler : Aspose.Html.Net.MessageHandler
{
    private const string AuthHeader = "Authorization";

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        if (string.IsNullOrEmpty(context.Request.Headers[AuthHeader]))
        {
            context.Response.StatusCode = HttpStatusCode.Unauthorized;
            return;
        }
        Next(context);
    }
}

class LogHandler : Aspose.Html.Net.MessageHandler
{
    private readonly List<string> _logs = new List<string>();

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        _logs.Add("URL: " + context.Request.RequestUri + " | Status: " + context.Response.StatusCode);
    }

    public IReadOnlyList<string> Logs => _logs;
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            string sampleHtmlPath = Path.Combine(inputFolder, "sample.html");
            if (!File.Exists(sampleHtmlPath))
            {
                File.WriteAllText(sampleHtmlPath, "<!DOCTYPE html><html><body><h1>Sample</h1></body></html>");
            }

            // Configure Aspose.Html with custom network handlers
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new Handler());
            network.MessageHandlers.Add(new AuthHandler());
            network.MessageHandlers.Add(new LogHandler());

            var processedFiles = new HashSet<string>();

            // Bounded polling loop (max 5 iterations)
            for (int iteration = 0; iteration < 5; iteration++)
            {
                string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
                foreach (string htmlPath in htmlFiles)
                {
                    if (processedFiles.Contains(htmlPath))
                        continue;

                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                    {
                        string outputPdfPath = Path.Combine(outputFolder,
                            Path.GetFileNameWithoutExtension(htmlPath) + ".pdf");

                        PdfSaveOptions pdfOptions = new PdfSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPdfPath);
                    }

                    processedFiles.Add(htmlPath);
                }

                Thread.Sleep(200);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}