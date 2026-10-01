// Write a script that archives original MHTML files after successful conversion to DOCX.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string sourcePath = "sample.mhtml";
            string outputPath = "output.docx";
            string archiveDirectory = "archive";

            // Ensure the archive directory exists
            if (!Directory.Exists(archiveDirectory))
            {
                Directory.CreateDirectory(archiveDirectory);
            }

            // Create a minimal sample MHTML file if it does not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<html><body><p>Sample MHTML content</p></body></html>");
            }

            // Open the MHTML file stream
            using (FileStream inputStream = File.OpenRead(sourcePath))
            {
                // Set DOCX save options
                Aspose.Html.Saving.DocSaveOptions saveOptions = new Aspose.Html.Saving.DocSaveOptions();

                // Convert MHTML to DOCX
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, saveOptions, outputPath);
            }

            // Archive the original MHTML file
            string archivePath = Path.Combine(archiveDirectory, Path.GetFileName(sourcePath));
            File.Move(sourcePath, archivePath, overwrite: true);

            Console.WriteLine("Conversion succeeded. Original file archived to: " + archivePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}