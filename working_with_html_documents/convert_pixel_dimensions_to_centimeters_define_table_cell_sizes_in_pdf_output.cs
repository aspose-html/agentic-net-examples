// Convert pixel dimensions to centimeters and use them to define table cell sizes in PDF output.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Pixel dimensions
            double widthPixels = 200;
            double heightPixels = 100;
            const double ppi = 96.0;

            // Convert to inches
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            // Convert to centimeters
            double widthCentimeters = widthInches * 2.54;
            double heightCentimeters = heightInches * 2.54;

            Console.WriteLine($"Width: {widthCentimeters:F2} cm");
            Console.WriteLine($"Height: {heightCentimeters:F2} cm");

            // Build HTML with a table cell sized using the calculated centimeters
            string htmlContent = $@"
                <html>
                <head>
                    <style>
                        table {{ border-collapse: collapse; }}
                        td {{ border: 1px solid #000; width: {widthCentimeters:F2}cm; height: {heightCentimeters:F2}cm; }}
                    </style>
                </head>
                <body>
                    <table>
                        <tr><td>Cell</td></tr>
                    </table>
                </body>
                </html>";

            // PDF conversion options
            PdfSaveOptions options = new PdfSaveOptions();

            // Convert HTML string to PDF
            Converter.ConvertHTML(htmlContent, "", options, "output.pdf");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}