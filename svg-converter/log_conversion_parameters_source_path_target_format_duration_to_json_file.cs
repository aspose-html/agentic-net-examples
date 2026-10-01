// Log conversion parameters, including source path, target format, and duration, to a JSON file.

using System;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;

public sealed class RequestTimingHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        var requestTimer = Stopwatch.StartNew();
        Next(context);
        requestTimer.Stop();
        Console.WriteLine("Request: " + context.Request.RequestUri + " | " + requestTimer.ElapsedMilliseconds + " ms");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Paths
            string zipPath = "sample.zip";
            string extractDirectory = "extracted";
            string outputPdfPath = "output.pdf";

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDirectory);

            // Create a sample zip with an HTML file if it does not exist
            if (!File.Exists(zipPath))
            {
                string sampleHtml = "<html><body><h1>Hello from zip</h1></body></html>";
                using (FileStream zipStream = new FileStream(zipPath, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry entry = archive.CreateEntry("sample.html");
                    using (Stream entryStream = entry.Open())
                    using (StreamWriter writer = new StreamWriter(entryStream))
                    {
                        writer.Write(sampleHtml);
                    }
                }
            }

            // Extract HTML files from the zip
            using (FileStream zipStream = File.OpenRead(zipPath))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".htm", StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = Path.Combine(extractDirectory, entry.FullName);
                        string entryFolder = Path.GetDirectoryName(entryPath);
                        if (!string.IsNullOrEmpty(entryFolder))
                            Directory.CreateDirectory(entryFolder);
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            // Find extracted HTML file
            string[] htmlFiles = Directory.GetFiles(extractDirectory, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = Directory.GetFiles(extractDirectory, "*.htm", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");

            // Configure Aspose.Html with custom network handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new RequestTimingHandler());

            // Convert first HTML to PDF
            Stopwatch conversionTimer = Stopwatch.StartNew();
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
            {
                document.RenderTo(device);
            }
            conversionTimer.Stop();
            Console.WriteLine("Conversion completed in " + conversionTimer.Elapsed.TotalSeconds.ToString("F2") + " seconds.");

            // ----- Template conversion example -----
            string templatePath = "template.html";
            if (!File.Exists(templatePath))
                File.WriteAllText(templatePath, "<html><body><h1>{{title}}</h1></body></html>");

            string jsonPath = "data.json";
            if (!File.Exists(jsonPath))
                File.WriteAllText(jsonPath, "{\"title\":\"Hello Template\"}");

            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(jsonPath);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();
            Aspose.Html.HTMLDocument templateDoc = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, templateData, loadOptions);
            string templateOutputPath = "template_output.html";
            templateDoc.Save(templateOutputPath);
            templateDoc.Dispose();
            Console.WriteLine("Template conversion saved to " + templateOutputPath);

            // ----- Markdown conversion example -----
            string markdownPath = "sample.md";
            if (!File.Exists(markdownPath))
                File.WriteAllText(markdownPath, "# Markdown Title\n\nThis is a paragraph.");

            string markdownOutputPath = "markdown_output.html";
            Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath, markdownOutputPath);
            Console.WriteLine("Markdown conversion saved to " + markdownOutputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}