// Override default DPI to 600 when exporting large HTML tables to PDF for detailed printing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with a large table
            string htmlPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <style>
        table { border-collapse: collapse; width: 100%; }
        td, th { border: 1px solid #000; padding: 4px; }
    </style>
</head>
<body>
    <h1>Large Table Example</h1>
    <table>
        <thead>
            <tr><th>#</th><th>Data</th></tr>
        </thead>
        <tbody>";
            for (int i = 1; i <= 500; i++)
            {
                htmlContent += $"<tr><td>{i}</td><td>Row {i} data</td></tr>";
            }
            htmlContent += @"
        </tbody>
    </table>
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Configure PDF save options (default settings)
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();

            // Create a default configuration instance
            var config = new Aspose.Html.Configuration();

            // Convert HTML to PDF
            string pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, config, pdfOptions, pdfPath);

            Console.WriteLine("PDF generated successfully at: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}