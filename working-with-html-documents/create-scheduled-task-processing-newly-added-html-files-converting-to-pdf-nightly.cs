// Create a scheduled task that processes newly added HTML files, converting them to PDF nightly.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "InputHtml";
            string outputDir = "OutputPdf";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Create a sample HTML file if none exist
            if (Directory.GetFiles(inputDir, "*.html").Length == 0)
            {
                string samplePath = Path.Combine(inputDir, "sample.html");
                File.WriteAllText(samplePath, "<html><body><h1>Sample Document</h1></body></html>");
            }

            foreach (string htmlPath in Directory.GetFiles(inputDir, "*.html"))
            {
                var configuration = new Configuration();
                // Optional: configure network service if needed
                INetworkService network = configuration.GetService<INetworkService>();

                using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
                {
                    string pdfPath = Path.ChangeExtension(htmlPath, ".pdf");
                    var options = new PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                    Console.WriteLine($"Converted: {htmlPath} -> {pdfPath}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}