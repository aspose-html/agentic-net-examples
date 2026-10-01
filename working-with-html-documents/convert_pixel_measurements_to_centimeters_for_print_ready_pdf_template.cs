// Convert pixel measurements to centimeters for use in a print‑ready PDF template.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Predefined pixel values
            double widthPixels = 800;
            double heightPixels = 600;

            const double ppi = 96.0;

            // Convert to inches
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            // Convert to centimeters
            double widthCentimeters = widthInches * 2.54;
            double heightCentimeters = heightInches * 2.54;

            // Convert to millimeters
            double widthMillimeters = widthCentimeters * 10.0;
            double heightMillimeters = heightCentimeters * 10.0;

            // Convert to points
            double widthPoints = widthInches * 72.0;
            double heightPoints = heightInches * 72.0;

            // Convert to picas
            double widthPicas = widthInches * 6.0;
            double heightPicas = heightInches * 6.0;

            // Output results
            Console.WriteLine($"Width: {widthPixels} px = {widthInches:F2} in = {widthCentimeters:F2} cm = {widthMillimeters:F2} mm = {widthPoints:F2} pt = {widthPicas:F2} pc");
            Console.WriteLine($"Height: {heightPixels} px = {heightInches:F2} in = {heightCentimeters:F2} cm = {heightMillimeters:F2} mm = {heightPoints:F2} pt = {heightPicas:F2} pc");

            // Additional conversions
            double pixels = 300;
            double millimeters = (pixels / ppi) * 25.4;
            Console.WriteLine($"Pixel: {pixels} = {millimeters:F2} mm");

            double centimeters = pixels / 96.0 * 2.54;
            Console.WriteLine($"Length in centimeters: {centimeters:F2}");

            // Prepare sample HTML file
            string htmlPath = Path.Combine(Path.GetTempPath(), "sample.html");
            string htmlContent = "<html><body><h1>Hello Aspose.HTML</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // ---------- Image conversion (JPEG) ----------
            var imageOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            imageOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromMillimeters(widthMillimeters),
                    Aspose.Html.Drawing.Length.FromMillimeters(heightMillimeters)));

            string jpegOutput = Path.Combine(Path.GetTempPath(), "output.jpg");
            using (var imageDevice = new Aspose.Html.Rendering.Image.ImageDevice(imageOptions, jpegOutput))
            {
                document.RenderTo(imageDevice);
            }
            Console.WriteLine($"JPEG image saved to: {jpegOutput}");

            // ---------- PDF rendering with margins ----------
            double leftPixels = 50, topPixels = 50, rightPixels = 50, bottomPixels = 50;
            double leftInches = leftPixels / ppi;
            double topInches = topPixels / ppi;
            double rightInches = rightPixels / ppi;
            double bottomInches = bottomPixels / ppi;

            var margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(topInches),
                Aspose.Html.Drawing.Length.FromInches(rightInches),
                Aspose.Html.Drawing.Length.FromInches(bottomInches),
                Aspose.Html.Drawing.Length.FromInches(leftInches));

            var pdfOptions = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            pdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8),
                    Aspose.Html.Drawing.Length.FromInches(11)),
                margin);

            string pdfOutput = Path.Combine(Path.GetTempPath(), "output.pdf");
            using (var pdfDevice = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfOptions, pdfOutput))
            {
                document.RenderTo(pdfDevice);
            }
            Console.WriteLine($"PDF document saved to: {pdfOutput}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}