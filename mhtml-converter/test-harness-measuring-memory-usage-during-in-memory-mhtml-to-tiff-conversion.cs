// Develop a test harness that measures memory usage during in‑memory MHTML to TIFF conversion.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample MHTML file (simple HTML content for demonstration)
            string mhtmlPath = "sample.mhtml";
            if (!File.Exists(mhtmlPath))
            {
                File.WriteAllText(mhtmlPath, "<html><body><h1>Test MHTML Content</h1></body></html>");
            }

            // Output TIFF path
            string outputTiffPath = "output.tiff";

            // Measure memory before conversion
            long memoryBefore = GC.GetTotalMemory(true);

            // Open input stream
            using (FileStream inputStream = File.OpenRead(mhtmlPath))
            {
                // Configure image save options for TIFF
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                options.UseAntialiasing = true; // optional configuration

                // Perform conversion from MHTML to TIFF
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputTiffPath);
            }

            // Measure memory after conversion
            long memoryAfter = GC.GetTotalMemory(true);
            long memoryUsed = memoryAfter - memoryBefore;

            Console.WriteLine($"Memory used during conversion: {memoryUsed} bytes");
            Console.WriteLine($"TIFF file saved to: {Path.GetFullPath(outputTiffPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}