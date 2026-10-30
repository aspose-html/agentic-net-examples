// Implement logging of conversion parameters such as output format and save options for audit trails.

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string inputHtmlPath = "sample.html";
            string outputPdfPath = "output.pdf";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputHtmlPath))
            {
                File.WriteAllText(inputHtmlPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            // Log conversion parameters for audit trail
            Console.WriteLine("Conversion parameters:");
            Console.WriteLine("Input file: " + inputHtmlPath);
            Console.WriteLine("Output file: " + outputPdfPath);
            Console.WriteLine("Output format: PDF");
            PdfSaveOptions options = new PdfSaveOptions();
            Console.WriteLine("Save options type: " + options.GetType().FullName);

            // Record start time
            Stopwatch conversionTimer = Stopwatch.StartNew();

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(inputHtmlPath, options, outputPdfPath);

            // Record end time
            conversionTimer.Stop();
            Console.WriteLine("Conversion completed in " + conversionTimer.Elapsed.TotalSeconds.ToString("F2") + " seconds.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}