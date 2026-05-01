// Set PixelsPerInch to 96 globally and verify conversion accuracy across multiple document types.

using System;
using System.IO;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            const double ppi = 96.0;
            double widthPixels = 800;
            double heightPixels = 600;
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;
            double widthMillimeters = widthInches * 25.4;
            double heightMillimeters = heightInches * 25.4;
            double widthCentimeters = widthInches * 2.54;
            double heightCentimeters = heightInches * 2.54;

            Console.WriteLine($"Width: {widthPixels} px = {widthInches:F2} in = {widthMillimeters:F2} mm = {widthCentimeters:F2} cm");
            Console.WriteLine($"Height: {heightPixels} px = {heightInches:F2} in = {heightMillimeters:F2} mm = {heightCentimeters:F2} cm");

            string htmlPath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(htmlPath, "<html><body><h1>Test</h1></body></html>");

            string pdfPath = Path.Combine(Path.GetTempPath(), "output.pdf");
            PdfSaveOptions pdfOptions = new PdfSaveOptions();
            pdfOptions.PageSetup.AnyPage = new Page(new Size(Length.FromMillimeters(widthMillimeters), Length.FromMillimeters(heightMillimeters)));
            Converter.ConvertHTML(htmlPath, pdfOptions, pdfPath);
            Console.WriteLine($"PDF generated: {pdfPath}, size: {new FileInfo(pdfPath).Length} bytes");

            string jpegPath = Path.Combine(Path.GetTempPath(), "output.jpg");
            ImageSaveOptions imgOptions = new ImageSaveOptions(ImageFormat.Jpeg);
            imgOptions.PageSetup.AnyPage = new Page(new Size(Length.FromPixels(widthPixels), Length.FromPixels(heightPixels)));
            Converter.ConvertHTML(htmlPath, imgOptions, jpegPath);
            Console.WriteLine($"JPEG generated: {jpegPath}, size: {new FileInfo(jpegPath).Length} bytes");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}