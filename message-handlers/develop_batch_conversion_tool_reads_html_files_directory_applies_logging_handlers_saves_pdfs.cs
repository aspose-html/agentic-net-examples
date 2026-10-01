// Develop a batch conversion tool that reads HTML files from a directory, applies logging handlers, and saves PDFs.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class LogHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        Console.WriteLine(context.Request.RequestUri + " | " + context.Response.StatusCode);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "InputHtml";
            // Ensure the input directory exists
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                // Create a sample HTML file
                string samplePath = Path.Combine(inputDir, "sample.html");
                File.WriteAllText(samplePath, "<html><body><h1>Sample</h1></body></html>");
            }

            ConvertHtmlFilesInFolder(inputDir);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ConvertHtmlFilesInFolder(string folderPath)
    {
        foreach (string htmlPath in Directory.GetFiles(folderPath, "*.html"))
        {
            // Create configuration and attach logging handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new LogHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                string pdfPath = Path.ChangeExtension(htmlPath, ".pdf");
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                Console.WriteLine("Converted: " + pdfPath);
            }
        }
    }
}