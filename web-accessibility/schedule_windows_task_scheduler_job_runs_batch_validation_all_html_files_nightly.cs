// Schedule a Windows Task Scheduler job that runs batch validation on all HTML files nightly.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "Input";
            string outputFolder = "Output";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a minimal sample MHTML file if none exist
            string sampleMhtmlPath = Path.Combine(inputFolder, "sample.mht");
            if (!File.Exists(sampleMhtmlPath))
            {
                // Simple HTML content saved with .mht extension (for demo purposes)
                File.WriteAllText(sampleMhtmlPath, "<html><body><h1>Sample MHTML</h1></body></html>");
            }

            ConvertMhtmlFilesInFolder(inputFolder, outputFolder);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ConvertMhtmlFilesInFolder(string inputFolder, string outputFolder)
    {
        foreach (string mhtmlPath in Directory.GetFiles(inputFolder, "*.mht"))
        {
            using (FileStream stream = File.OpenRead(mhtmlPath))
            {
                // Configure network logging (optional)
                var configuration = new Aspose.Html.Configuration();
                var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
                network.MessageHandlers.Add(new LogHandler());

                var options = new Aspose.Html.Saving.PdfSaveOptions();

                string pdfFileName = Path.GetFileNameWithoutExtension(mhtmlPath) + ".pdf";
                string pdfPath = Path.Combine(outputFolder, pdfFileName);

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, pdfPath);
                Console.WriteLine($"Converted: {Path.GetFileName(mhtmlPath)} -> {pdfFileName}");
            }
        }
    }
}

class LogHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        Console.WriteLine($"{context.Request.RequestUri} | {context.Response.StatusCode}");
    }
}