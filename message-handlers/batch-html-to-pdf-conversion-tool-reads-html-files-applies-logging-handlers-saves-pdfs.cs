// Develop a batch conversion tool that reads HTML files from a directory, applies logging handlers, and saves PDFs.

using System;
using System.IO;
using Aspose.Html.Net;

class LogHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        Console.WriteLine($"{context.Request.RequestUri} | {context.Response.StatusCode}");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = @"C:\InputHtml";
            string outputFolder = @"C:\OutputPdf";

            Directory.CreateDirectory(outputFolder);
            ConvertHtmlFilesInFolder(inputFolder, outputFolder);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertHtmlFilesInFolder(string inputFolder, string outputFolder)
    {
        foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new LogHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                string pdfFileName = Path.GetFileNameWithoutExtension(htmlPath) + ".pdf";
                string pdfPath = Path.Combine(outputFolder, pdfFileName);

                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

                Console.WriteLine($"Converted: {htmlPath} -> {pdfPath}");
            }
        }
    }
}