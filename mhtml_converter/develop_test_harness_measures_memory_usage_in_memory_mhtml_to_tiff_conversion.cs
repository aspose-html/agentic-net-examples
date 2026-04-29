// Develop a test harness that measures memory usage during in‑memory MHTML to TIFF conversion.

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace MhtmlToTiffMemoryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source MHTML file
                string mhtmlPath = "input.mhtml";
                // Path for the output TIFF file
                string tiffPath = "output.tiff";

                // Measure memory before conversion
                long memoryBefore = GC.GetTotalMemory(true);
                Process proc = Process.GetCurrentProcess();
                long privateBefore = proc.PrivateMemorySize64;

                // Open the MHTML file as a stream
                using (Stream mhtmlStream = File.OpenRead(mhtmlPath))
                {
                    // Create image save options for TIFF format
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                    // Optional: configure rendering properties
                    options.UseAntialiasing = true;
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    // Convert MHTML to TIFF and save to file
                    Converter.ConvertMHTML(mhtmlStream, options, tiffPath);
                }

                // Force garbage collection and measure memory after conversion
                GC.Collect();
                GC.WaitForPendingFinalizers();
                long memoryAfter = GC.GetTotalMemory(true);
                proc.Refresh();
                long privateAfter = proc.PrivateMemorySize64;

                // Output memory usage statistics
                Console.WriteLine($"Memory (GC) before: {memoryBefore:N0} bytes");
                Console.WriteLine($"Memory (GC) after : {memoryAfter:N0} bytes");
                Console.WriteLine($"GC memory delta   : {memoryAfter - memoryBefore:N0} bytes");
                Console.WriteLine($"Private memory before: {privateBefore:N0} bytes");
                Console.WriteLine($"Private memory after : {privateAfter:N0} bytes");
                Console.WriteLine($"Private memory delta   : {privateAfter - privateBefore:N0} bytes");
                Console.WriteLine("MHTML to TIFF conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}