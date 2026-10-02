// Log conversion parameters, including source path, target format, and duration, to a JSON file.

using System;
using System.IO;
using System.Diagnostics;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;

public sealed class Program
{
    public static void Main()
    {
        try
        {
            // Define paths
            string sourcePath = "sample.html";
            string outputPdfPath = "output.pdf";
            string jsonPath = "conversion_log.json";

            // Ensure sample HTML exists
            if (!File.Exists(sourcePath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(sourcePath, sampleHtml);
            }

            // Perform conversion and measure duration
            Stopwatch conversionTimer = Stopwatch.StartNew();
            using (HTMLDocument document = new HTMLDocument(sourcePath))
            using (PdfDevice device = new PdfDevice(outputPdfPath))
            {
                document.RenderTo(device);
            }
            conversionTimer.Stop();

            // Prepare log data
            var log = new
            {
                sourcePath = sourcePath,
                targetFormat = "pdf",
                durationSeconds = conversionTimer.Elapsed.TotalSeconds
            };

            // Serialize to JSON and write to file
            string jsonContent = JsonSerializer.Serialize(log, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonPath, jsonContent);

            Console.WriteLine("Conversion completed in " + conversionTimer.Elapsed.TotalSeconds.ToString("F2") + " seconds.");
            Console.WriteLine("Log written to " + jsonPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}