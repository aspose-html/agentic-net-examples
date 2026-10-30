// Configure PdfSaveOptions with custom margins, then convert an HTML file containing canvas to PDF.

using System;
using System.IO;
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
            // Define input and output paths
            string sourcePath = "sample.html";
            string savePath = "output.pdf";

            // Create a minimal HTML file with a canvas element
            string htmlContent = @"<!DOCTYPE html>
<html>
<body>
<canvas id='myCanvas' width='500' height='200'></canvas>
<script>
var canvas = document.getElementById('myCanvas');
var ctx = canvas.getContext('2d');
ctx.fillStyle = 'lightblue';
ctx.fillRect(0,0,500,200);
ctx.fillStyle = 'black';
ctx.font = '30px Arial';
ctx.fillText('Hello Canvas', 50, 100);
</script>
</body>
</html>";
            File.WriteAllText(sourcePath, htmlContent);

            // Load the HTML document from the file
            HTMLDocument document = new HTMLDocument(sourcePath);

            // Configure PDF save options with custom page size and margins
            PdfSaveOptions options = new PdfSaveOptions();

            Size pageSize = new Size(
                Length.FromInches(8.27),   // Width (A4)
                Length.FromInches(11.69)   // Height (A4)
            );

            Margin pageMargin = new Margin(72, 72, 72, 72); // 1 inch margins (72 points)

            Page page = new Page(pageSize, pageMargin);
            options.PageSetup.AnyPage = page;

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + Path.GetFullPath(savePath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}