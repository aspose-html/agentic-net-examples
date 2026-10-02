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
            string inputHtmlPath = "sample.html";
            string outputPdfPath = "output.pdf";

            // Ensure sample HTML file exists
            if (!File.Exists(inputHtmlPath))
            {
                File.WriteAllText(inputHtmlPath, "<html><body><h1>Hello Aspose HTML</h1></body></html>");
            }

            string resultPath = ConvertHtmlToPdf(inputHtmlPath, outputPdfPath);
            Console.WriteLine("Generated PDF: " + resultPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string ConvertHtmlToPdf(string inputHtmlPath, string outputPdfPath)
    {
        // Log conversion parameters
        Console.WriteLine("Conversion parameters:");
        Console.WriteLine("Input HTML path: " + inputHtmlPath);
        Console.WriteLine("Output format: PDF");

        PdfSaveOptions options = new PdfSaveOptions();
        Console.WriteLine("Save options type: " + options.GetType().FullName);

        // Record start time
        Stopwatch conversionTimer = Stopwatch.StartNew();

        // Read HTML content
        string htmlContent = File.ReadAllText(inputHtmlPath);

        // Perform conversion
        Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, options, outputPdfPath);

        // Record end time
        conversionTimer.Stop();
        Console.WriteLine("Conversion completed in " + conversionTimer.Elapsed.TotalSeconds.ToString("F2") + " seconds.");

        return outputPdfPath;
    }
}