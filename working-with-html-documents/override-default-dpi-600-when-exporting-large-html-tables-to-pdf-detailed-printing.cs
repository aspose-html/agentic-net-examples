// Override default DPI to 600 when exporting large HTML tables to PDF for detailed printing.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "sample.html";
            string outputPath = "output.pdf";

            // Create a sample HTML file with a large table if it does not exist
            if (!File.Exists(inputPath))
            {
                var sb = new StringBuilder();
                sb.AppendLine("<html><head><style>table, th, td { border: 1px solid black; border-collapse: collapse; }</style></head><body>");
                sb.AppendLine("<table>");
                for (int i = 0; i < 100; i++)
                {
                    sb.AppendLine("<tr>");
                    for (int j = 0; j < 10; j++)
                    {
                        sb.AppendLine($"<td>R{i}C{j}</td>");
                    }
                    sb.AppendLine("</tr>");
                }
                sb.AppendLine("</table></body></html>");
                File.WriteAllText(inputPath, sb.ToString());
            }

            // Read HTML content and determine base URI
            string htmlContent = File.ReadAllText(inputPath);
            string baseUri = new Uri(Path.GetFullPath(inputPath)).AbsoluteUri;

            // Configure PDF save options (no DPI properties needed)
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, pdfOptions, outputPath);

            Console.WriteLine("PDF conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}