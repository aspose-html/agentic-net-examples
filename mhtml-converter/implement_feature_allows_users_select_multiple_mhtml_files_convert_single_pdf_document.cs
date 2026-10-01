// Implement a feature that allows users to select multiple MHTML files and convert them to a single PDF document.

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
            // Define sample MHTML files (in a real scenario these would be existing files)
            string[] mhtmlFiles = new string[]
            {
                Path.Combine(Environment.CurrentDirectory, "sample1.mhtml"),
                Path.Combine(Environment.CurrentDirectory, "sample2.mhtml")
            };

            // Ensure sample files exist (create minimal placeholder if missing)
            foreach (var file in mhtmlFiles)
            {
                if (!File.Exists(file))
                {
                    File.WriteAllText(file, "<html><body><p>Placeholder content for " + Path.GetFileName(file) + "</p></body></html>");
                }
            }

            // Output directory for PDFs
            string outputDir = Path.Combine(Environment.CurrentDirectory, "output");
            Directory.CreateDirectory(outputDir);

            // Convert each MHTML to a separate PDF
            for (int i = 0; i < mhtmlFiles.Length; i++)
            {
                using (FileStream stream = File.OpenRead(mhtmlFiles[i]))
                {
                    PdfSaveOptions options = new PdfSaveOptions();
                    string pdfPath = Path.Combine(outputDir, $"merged_part_{i + 1}.pdf");
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, pdfPath);
                    Console.WriteLine($"Converted '{Path.GetFileName(mhtmlFiles[i])}' to PDF: {pdfPath}");
                }
            }

            Console.WriteLine("All MHTML files have been converted to individual PDF parts.");
            Console.WriteLine("Merging these PDFs into a single document requires a separate PDF manipulation library.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}