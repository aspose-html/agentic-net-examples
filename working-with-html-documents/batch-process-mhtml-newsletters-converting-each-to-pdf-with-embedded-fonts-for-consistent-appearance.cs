// Batch process MHTML newsletters, converting each to PDF with embedded fonts for consistent appearance.

using System;
using System.IO;

namespace BatchMhtmlToPdf
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Fonts folder (adjust path as needed)
                string fontsFolder = Path.Combine(Directory.GetCurrentDirectory(), "fonts");
                if (!Directory.Exists(fontsFolder))
                {
                    Directory.CreateDirectory(fontsFolder);
                }

                // Configure Aspose.HTML to use the fonts folder
                Aspose.Html.Configuration config = new Aspose.Html.Configuration();
                Aspose.Html.Services.IUserAgentService userAgent = config.GetService<Aspose.Html.Services.IUserAgentService>();
                userAgent.FontsSettings.SetFontsLookupFolder(fontsFolder);

                // Input MHTML files (hard‑coded list)
                string[] inputFiles = new string[]
                {
                    Path.Combine(Directory.GetCurrentDirectory(), "newsletter1.mhtml"),
                    Path.Combine(Directory.GetCurrentDirectory(), "newsletter2.mhtml")
                };

                // Output directory
                string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "output");
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                foreach (string inputPath in inputFiles)
                {
                    // Create a minimal sample MHTML file if it does not exist
                    if (!File.Exists(inputPath))
                    {
                        File.WriteAllText(inputPath, "<html><body><p>Sample newsletter</p></body></html>");
                    }

                    using (FileStream stream = File.OpenRead(inputPath))
                    {
                        string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                        Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                        Console.WriteLine($"Converted '{inputPath}' to PDF at '{outputPath}'.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}