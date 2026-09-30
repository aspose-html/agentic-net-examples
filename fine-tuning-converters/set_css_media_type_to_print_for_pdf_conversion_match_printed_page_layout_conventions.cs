// Set CSS media type to Print for PDF conversion to match printed page layout conventions.

using System;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <style>
        @media print {
            body { background-color: aliceblue; }
        }
    </style>
</head>
<body>
    <h1>Hello, PDF!</h1>
    <p>This PDF is generated with CSS media type set to print.</p>
</body>
</html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.AliceBlue;
            options.JpegQuality = 90;

            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(595, 842),
                new Aspose.Html.Drawing.Margin(20, 20, 20, 20));
            options.PageSetup.AnyPage = page;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.pdf");
            Console.WriteLine("PDF conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}