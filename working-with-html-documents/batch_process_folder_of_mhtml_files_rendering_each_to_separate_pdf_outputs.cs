// Batch process a folder of MHTML files, rendering each to separate PDF outputs.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class logHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        base.Next(context);
        Console.WriteLine($"{context.Request.RequestUri} | {context.Response.StatusCode}");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "Input";

            if (!Directory.Exists(inputDir))
                Directory.CreateDirectory(inputDir);

            // Convert HTML files with network logging
            foreach (string htmlPath in Directory.GetFiles(inputDir, "*.html"))
            {
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                INetworkService network = configuration.GetService<INetworkService>();
                network.MessageHandlers.Add(new logHandler());

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                {
                    string pdfPath = Path.ChangeExtension(htmlPath, ".pdf");
                    PdfSaveOptions options = new PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                    Console.WriteLine($"Converted HTML: {htmlPath} -> {pdfPath}");
                }
            }

            // Convert MHTML files in the folder
            ConvertMhtmlFilesInFolder(inputDir);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        string[] mhtmlFiles = Directory.GetFiles(folderPath, "*.mhtml");
        foreach (string mhtmlPath in mhtmlFiles)
        {
            using (FileStream stream = File.OpenRead(mhtmlPath))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                string outputPath = Path.ChangeExtension(mhtmlPath, ".pdf");
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                Console.WriteLine($"Converted MHTML: {mhtmlPath} -> {outputPath}");
            }
        }
    }
}