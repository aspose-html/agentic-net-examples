// Handle conversion exceptions by wrapping Converter.ConvertSVG calls in try‑catch blocks and logging errors.

using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            ConvertSvgExample();

            // Prepare a minimal MHTML file
            string mhtmlPath = "sample.mhtml";
            string mhtmlContent = "From: <Saved by WebKit>\nSubject: \nDate: \nMIME-Version: 1.0\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\n\n------=_NextPart_000_0000\nContent-Type: text/html; charset=\"utf-8\"\nContent-Transfer-Encoding: quoted-printable\n\n<html><body><h1>Hello MHTML</h1></body></html>\n------=_NextPart_000_0000--";
            File.WriteAllText(mhtmlPath, mhtmlContent);

            ConvertMhtmlToPdfWithRetry(mhtmlPath, "output_mhtml.pdf", 3);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    static void ConvertSvgExample()
    {
        string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
        string baseUri = "about:blank";
        string outputPath = "output_svg.pdf";
        var options = new Aspose.Html.Saving.PdfSaveOptions();

        try
        {
            Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, options, outputPath);
            Console.WriteLine("SVG converted to PDF successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"SVG conversion failed: {ex.Message}");
        }
    }

    static void ConvertMhtmlToPdfWithRetry(string inputPath, string outputPath, int maxAttempts)
    {
        Exception lastException = null;

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    var options = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                    Console.WriteLine($"MHTML conversion succeeded on attempt {attempt}.");
                    return;
                }
            }
            catch (IOException ex)
            {
                lastException = ex;
                Console.WriteLine($"Attempt {attempt} failed with I/O error: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                lastException = ex;
                Console.WriteLine($"Attempt {attempt} failed with access error: {ex.Message}");
            }

            Thread.Sleep(1000);
        }

        throw lastException ?? new Exception("MHTML conversion failed after all attempts.");
    }
}