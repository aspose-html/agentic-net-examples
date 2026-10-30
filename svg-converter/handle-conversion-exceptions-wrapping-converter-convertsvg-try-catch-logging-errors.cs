// Handle conversion exceptions by wrapping Converter.ConvertSVG calls in try‑catch blocks and logging errors.

using System;
using System.IO;
using System.Threading;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Sample MHTML to PDF conversion with retry
            string mhtmlInput = "sample.mhtml";
            string pdfOutput = "output.pdf";
            // Ensure sample MHTML file exists (create minimal placeholder if needed)
            if (!File.Exists(mhtmlInput))
            {
                File.WriteAllText(mhtmlInput, "<!DOCTYPE html><html><body><p>Sample MHTML content</p></body></html>");
            }
            ConvertMhtmlToPdfWithRetry(mhtmlInput, pdfOutput, 3);
            Console.WriteLine($"MHTML to PDF conversion succeeded: {pdfOutput}");

            // Sample SVG to PNG conversion with exception handling
            string svgInput = "sample.svg";
            string pngOutput = "output.png";
            // Ensure sample SVG file exists
            if (!File.Exists(svgInput))
            {
                File.WriteAllText(svgInput, "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"red\"/></svg>");
            }
            ConvertSvgToPng(svgInput, pngOutput);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    static void ConvertMhtmlToPdfWithRetry(string inputPath, string outputPath, int maxAttempts)
    {
        Exception lastException = null;
        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                using (Stream stream = File.OpenRead(inputPath))
                {
                    PdfSaveOptions options = new PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }
                // Success, exit the method
                return;
            }
            catch (IOException ioEx)
            {
                lastException = ioEx;
                Console.WriteLine($"Attempt {attempt} failed with I/O error: {ioEx.Message}");
            }
            catch (UnauthorizedAccessException uaEx)
            {
                lastException = uaEx;
                Console.WriteLine($"Attempt {attempt} failed with access error: {uaEx.Message}");
            }
            // Wait before next retry
            Thread.Sleep(1000);
        }
        // All attempts failed
        throw lastException ?? new Exception("Conversion failed after retries.");
    }

    static void ConvertSvgToPng(string svgPath, string pngPath)
    {
        try
        {
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, pngPath);
            Console.WriteLine($"SVG to PNG conversion succeeded: {pngPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error converting SVG to PNG: {ex.Message}");
        }
    }
}