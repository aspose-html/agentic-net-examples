// Develop a PowerShell script that calls the .NET assembly to batch convert MHTML files to DOCX.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace MhtmlToDocxBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define input and output directories (can be passed as arguments)
                string inputFolder = args.Length > 0 ? args[0] : @"C:\InputMhtml";
                string outputFolder = args.Length > 1 ? args[1] : @"C:\OutputDocx";

                // Ensure output directory exists
                Directory.CreateDirectory(outputFolder);

                // Get all .mhtml files in the input folder
                string[] mhtmlFiles = Directory.GetFiles(inputFolder, "*.mhtml");

                foreach (string mhtmlPath in mhtmlFiles)
                {
                    try
                    {
                        // Open the source MHTML file for reading
                        FileStream stream = File.OpenRead(mhtmlPath);

                        // Prepare the output DOCX file path
                        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(mhtmlPath);
                        string docxPath = Path.Combine(outputFolder, fileNameWithoutExt + ".docx");

                        // Convert MHTML to DOCX using Aspose.Html
                        Converter.ConvertMHTML(stream, new DocSaveOptions(), docxPath);

                        // Close the input stream
                        stream.Close();

                        Console.WriteLine($"Converted: {mhtmlPath} -> {docxPath}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to convert '{mhtmlPath}': {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Batch conversion error: {ex.Message}");
            }
        }
    }
}