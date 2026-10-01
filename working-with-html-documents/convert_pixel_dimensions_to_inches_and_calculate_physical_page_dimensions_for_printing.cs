// Convert pixel dimensions to inches and use them to calculate physical page dimensions for printing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // ✔ Use predefined pixel values
            double widthPixels = 800;
            double heightPixels = 600;

            const double ppi = 96.0;

            // ✔ Convert to inches
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            // ✔ Convert to centimeters
            double widthCentimeters = widthInches * 2.54;
            double heightCentimeters = heightInches * 2.54;

            // ✔ Convert to millimeters
            double widthMillimeters = widthCentimeters * 10.0;
            double heightMillimeters = heightCentimeters * 10.0;

            // ✔ Convert to points
            double widthPoints = widthInches * 72.0;
            double heightPoints = heightInches * 72.0;

            // ✔ Convert to picas
            double widthPicas = widthInches * 6.0;
            double heightPicas = heightInches * 6.0;

            // ✔ Output results
            Console.WriteLine($"Width: {widthPixels} px = {widthInches:F2} in = {widthCentimeters:F2} cm = {widthMillimeters:F2} mm = {widthPoints:F2} pt = {widthPicas:F2} pc");
            Console.WriteLine($"Height: {heightPixels} px = {heightInches:F2} in = {heightCentimeters:F2} cm = {heightMillimeters:F2} mm = {heightPoints:F2} pt = {heightPicas:F2} pc");

            // Additional millimeter calculation (same as above)
            double widthMillimetersCalc = widthPixels / 96.0 * 25.4;
            double heightMillimetersCalc = heightPixels / 96.0 * 25.4;

            // Prepare sample MHTML file
            string inputPath = "sample.mht";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                string mhtmlContent =
@"From: <Saved by Aspose.Html>
Subject: Sample MHTML
Date: " + DateTime.UtcNow.ToString("R") + @"
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h1>Hello, MHTML!</h1></body></html>
------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            // Configure image save options with page size based on millimeters
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromMillimeters(widthMillimetersCalc),
                    Aspose.Html.Drawing.Length.FromMillimeters(heightMillimetersCalc)));

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);

            Console.WriteLine($"Conversion completed. Image saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}