// Convert pixel width to centimeters and use the result to set column widths in a PDF table.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // ---------- Unit conversion examples ----------
            double leftPixels = 72;
            double topPixels = 72;
            double rightPixels = 72;
            double bottomPixels = 72;

            double leftInches = leftPixels / 96.0;
            double topInches = topPixels / 96.0;
            double rightInches = rightPixels / 96.0;
            double bottomInches = bottomPixels / 96.0;

            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(topInches),
                Aspose.Html.Drawing.Length.FromInches(rightInches),
                Aspose.Html.Drawing.Length.FromInches(bottomInches),
                Aspose.Html.Drawing.Length.FromInches(leftInches));

            const double ppi = 96.0;
            double widthPixels = 800;
            double heightPixels = 600;

            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            double widthCentimeters = widthInches * 2.54;
            double heightCentimeters = heightInches * 2.54;

            double widthMillimeters = widthCentimeters * 10.0;
            double heightMillimeters = heightCentimeters * 10.0;

            double widthPoints = widthInches * 72.0;
            double heightPoints = heightInches * 72.0;

            double widthPicas = widthInches * 6.0;
            double heightPicas = heightInches * 6.0;

            Console.WriteLine($"Width: {widthPixels} px = {widthInches:F2} in = {widthCentimeters:F2} cm = {widthMillimeters:F2} mm = {widthPoints:F2} pt = {widthPicas:F2} pc");
            Console.WriteLine($"Height: {heightPixels} px = {heightInches:F2} in = {heightCentimeters:F2} cm = {heightMillimeters:F2} mm = {heightPoints:F2} pt = {heightPicas:F2} pc");

            double columnWidthPixels = 100;
            double rowHeightPixels = 50;
            double columnWidthMillimeters = columnWidthPixels / 96.0 * 25.4;
            double rowHeightMillimeters = rowHeightPixels / 96.0 * 25.4;

            Console.WriteLine($"Column width: {columnWidthPixels}px = {columnWidthMillimeters:F2} mm");
            Console.WriteLine($"Row height: {rowHeightPixels}px = {rowHeightMillimeters:F2} mm");

            double pixelsForCm = 96;
            double centimeters = pixelsForCm / 96.0 * 2.54;
            Console.WriteLine($"Length in centimeters: {centimeters:F2}");

            double pixelsForMm = 96;
            double millimeters = (pixelsForMm / ppi) * 25.4;
            Console.WriteLine($"Pixel: {pixelsForMm} = {millimeters:F2} mm");

            // ---------- Create a simple HTML document ----------
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello Aspose.HTML</h1></body></html>";
            string htmlPath = "sample.html";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // ---------- PDF rendering ----------
            string outputPdfPath = "output.pdf";

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8),
                    Aspose.Html.Drawing.Length.FromInches(11)),
                margin);

            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPdfPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine($"PDF generated at: {Path.GetFullPath(outputPdfPath)}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}