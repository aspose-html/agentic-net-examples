// Implement logging of conversion parameters such as output format and save options for audit trails.

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputHtmlPath = "sample.html";
            string outputPdfPath = "output.pdf";

            // Ensure sample HTML file exists
            if (!File.Exists(inputHtmlPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(inputHtmlPath, sampleHtml);
            }

            // Create PDF save options
            PdfSaveOptions options = new PdfSaveOptions();

            // Log conversion parameters
            Console.WriteLine("Conversion Parameters:");
            Console.WriteLine("  Output Format: PDF");
            Console.WriteLine("  Save Options Type: " + options.GetType().FullName);

            // Record start time
            Stopwatch conversionTimer = Stopwatch.StartNew();

            // Perform conversion
            string htmlContent = File.ReadAllText(inputHtmlPath);
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, options, outputPdfPath);

            // Record end time
            conversionTimer.Stop();
            Console.WriteLine("Conversion completed in " + conversionTimer.Elapsed.TotalSeconds.ToString("F2") + " seconds.");
            Console.WriteLine("Output file: " + Path.GetFullPath(outputPdfPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}