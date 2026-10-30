// Convert pixel dimensions to centimeters and use them to define table cell sizes in PDF output.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel dimensions
            double columnWidthPixels = 200.0;
            double rowHeightPixels = 100.0;
            const double ppi = 96.0;

            // Convert to centimeters
            double columnWidthCentimeters = columnWidthPixels / ppi * 2.54;
            double rowHeightCentimeters = rowHeightPixels / ppi * 2.54;

            // Output conversion results
            Console.WriteLine($"Column width: {columnWidthPixels}px = {columnWidthCentimeters:F2} cm");
            Console.WriteLine($"Row height: {rowHeightPixels}px = {rowHeightCentimeters:F2} cm");

            // Build HTML with a table using the converted sizes
            string htmlContent = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>Table with Converted Sizes</title>
    <style>
        table {{ border-collapse: collapse; }}
        td {{ border: 1px solid #000; text-align: center; }}
    </style>
</head>
<body>
    <table>
        <tr>
            <td style='width:{columnWidthCentimeters:F2}cm;height:{rowHeightCentimeters:F2}cm;'>
                Cell Content
            </td>
        </tr>
    </table>
</body>
</html>";

            // Load HTML document from string
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Set up PDF rendering options
            var margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(1),
                Aspose.Html.Drawing.Length.FromInches(1),
                Aspose.Html.Drawing.Length.FromInches(1),
                Aspose.Html.Drawing.Length.FromInches(1));

            var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8.5),
                    Aspose.Html.Drawing.Length.FromInches(11)),
                margin);

            // Define output PDF path
            string outputPath = "TableOutput.pdf";

            // Render to PDF
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine($"PDF generated successfully at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}