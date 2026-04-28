// Log each successful conversion with source path, destination path, and timestamp to a CSV audit file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace HtmlConversionAudit
{
    class Program
    {
        static void Main()
        {
            string inputHtml = "input.html";
            string outputPdf = "output.pdf";
            string auditCsv = "audit.csv";

            try
            {
                var options = new PdfSaveOptions();
                Converter.ConvertHTML(inputHtml, options, outputPdf);

                string timestamp = DateTime.Now.ToString("o");
                using (var writer = new StreamWriter(auditCsv, true))
                {
                    writer.WriteLine($"{inputHtml},{outputPdf},{timestamp}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}