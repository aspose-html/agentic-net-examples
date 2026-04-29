// Write a script that archives converted DOCX files to a zip archive after successful MHTML conversion.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define folders and zip archive path
            string inputFolder = "InputMhtml";
            string outputFolder = "OutputDocx";
            string zipPath = "ConvertedDocs.zip";

            // Ensure directories exist
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Convert each MHTML file to DOCX
            foreach (string mhtmlFile in Directory.GetFiles(inputFolder, "*.mhtml"))
            {
                string docxFile = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(mhtmlFile) + ".docx");

                // Open MHTML file stream
                System.IO.FileStream stream = System.IO.File.OpenRead(mhtmlFile);
                // Perform conversion using Aspose.Html
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, new Aspose.Html.Saving.DocSaveOptions(), docxFile);
                stream.Close();
            }

            // Archive all generated DOCX files into a zip file
            using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    foreach (string docxFile in Directory.GetFiles(outputFolder, "*.docx"))
                    {
                        archive.CreateEntryFromFile(docxFile, Path.GetFileName(docxFile));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}