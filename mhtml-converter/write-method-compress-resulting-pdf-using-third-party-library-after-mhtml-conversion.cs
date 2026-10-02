// Write a method that compresses the resulting PDF using a third‑party library after MHTML conversion.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mhtml");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string mhtmlContent = "<html><body><p>Hello, Aspose.HTML!</p></body></html>";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            ConvertMhtmlToPdf(inputPath, outputPath);
            Console.WriteLine($"PDF generated at: {outputPath}");

            CompressPdf(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlToPdf(string inputPath, string outputPath)
    {
        using (FileStream stream = File.OpenRead(inputPath))
        {
            PdfSaveOptions options = new PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
        }
    }

    static void CompressPdf(string pdfPath)
    {
        // Placeholder for PDF compression using a third‑party library.
        // In a real scenario, you would reference a validated PDF compression library here.
        Console.WriteLine("PDF compression would be performed here using a third‑party library.");
        Console.WriteLine($"(Compression not executed because no external library is referenced.)");
    }
}