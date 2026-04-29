// Write a script that archives original MHTML files after successful conversion to DOCX.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Path to the source MHTML file
            string inputPath = "input.mhtml";
            // Desired output DOCX file path
            string outputPath = "output.docx";

            // Open the MHTML file as a stream and convert it to DOCX
            using (FileStream stream = File.OpenRead(inputPath))
            {
                Converter.ConvertMHTML(stream, new DocSaveOptions(), outputPath);
            }

            // Archive the original MHTML file after successful conversion
            string archiveDir = "archive";
            Directory.CreateDirectory(archiveDir);
            string archivePath = Path.Combine(archiveDir, Path.GetFileName(inputPath));
            File.Move(inputPath, archivePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}