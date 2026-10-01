// Convert multiple website URLs in batch mode, storing each result in separate HTML files.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Prepare input directory and sample files
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "input");
            Directory.CreateDirectory(inputDir);

            string sample1Path = Path.Combine(inputDir, "sample1.html");
            string sample2Path = Path.Combine(inputDir, "sample2.html");

            if (!File.Exists(sample1Path))
            {
                File.WriteAllText(sample1Path, "<!DOCTYPE html><html><body><h1>Sample 1</h1></body></html>");
            }
            if (!File.Exists(sample2Path))
            {
                File.WriteAllText(sample2Path, "<!DOCTYPE html><html><body><h1>Sample 2</h1></body></html>");
            }

            // Input files
            string[] inputs = new string[] { sample1Path, sample2Path };

            // Convert each HTML file to JPEG with specific resolution
            for (int i = 0; i < inputs.Length; i++)
            {
                string inputPath = inputs[i];
                using (var document = new Aspose.Html.HTMLDocument(inputPath, Directory.GetCurrentDirectory()))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            // Convert all HTML files in the input folder to JPEG
            foreach (string htmlPath in Directory.GetFiles(inputDir, "*.html"))
            {
                using (var document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(htmlPath) + "_all.jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            // Create a new document, add a DIV element, and convert to JPEG
            using (var document = new Aspose.Html.HTMLDocument(inputs[0], Directory.GetCurrentDirectory()))
            {
                Aspose.Html.HTMLElement div = (Aspose.Html.HTMLElement)document.CreateElement("div");
                div.SetAttribute("style", "color:red; font-size:24px;");
                div.TextContent = "Hello Aspose!";
                document.Body.AppendChild(div);

                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                string outputPath = Path.Combine(outputDir, "document_with_div.jpg");
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }

            // Convert each HTML file to PDF with network logging
            foreach (string htmlPath in Directory.GetFiles(inputDir, "*.html"))
            {
                var configuration = new Aspose.Html.Configuration();
                var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
                network.MessageHandlers.Add(new LogHandler());

                using (var document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                {
                    string pdfPath = Path.ChangeExtension(htmlPath, ".pdf");
                    var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, pdfPath);
                }
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Custom network message handler for logging
class LogHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        Console.WriteLine($"{context.Request.RequestUri} | {context.Response.StatusCode}");
    }
}