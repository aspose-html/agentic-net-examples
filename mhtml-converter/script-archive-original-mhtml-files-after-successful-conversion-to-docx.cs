// Write a script that archives original MHTML files after successful conversion to DOCX.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define paths
            string inputPath = "sample.mhtml";
            string outputPath = "output.docx";
            string archiveDir = "archive";

            // Ensure archive directory exists
            if (!Directory.Exists(archiveDir))
            {
                Directory.CreateDirectory(archiveDir);
            }

            // Create a minimal sample MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                // Simple HTML content saved with .mhtml extension (for demo purposes)
                string sampleHtml = "<html><body><h1>Sample MHTML Content</h1></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Convert MHTML to DOCX
            using (Stream stream = File.OpenRead(inputPath))
            {
                DocSaveOptions options = new DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            // Archive original MHTML file
            string archivedPath = Path.Combine(archiveDir, Path.GetFileName(inputPath));
            if (File.Exists(archivedPath))
            {
                File.Delete(archivedPath);
            }
            File.Move(inputPath, archivedPath);

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine($"DOCX saved to: {outputPath}");
            Console.WriteLine($"Original MHTML archived to: {archivedPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}