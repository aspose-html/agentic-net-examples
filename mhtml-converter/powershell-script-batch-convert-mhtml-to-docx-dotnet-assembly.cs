// Develop a PowerShell script that calls the .NET assembly to batch convert MHTML files to DOCX.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "InputMhtml");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "OutputDocx");

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] mhtmlFiles = Directory.GetFiles(inputDirectory, "*.mhtml");
            if (mhtmlFiles.Length == 0)
            {
                Console.WriteLine("No MHTML files found in the input directory.");
                return;
            }

            foreach (string mhtmlPath in mhtmlFiles)
            {
                try
                {
                    using (FileStream inputStream = File.OpenRead(mhtmlPath))
                    {
                        Aspose.Html.Saving.DocSaveOptions saveOptions = new Aspose.Html.Saving.DocSaveOptions();
                        string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(mhtmlPath) + ".docx");
                        Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, saveOptions, outputPath);
                        Console.WriteLine($"Converted '{mhtmlPath}' to '{outputPath}'.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error converting file '{mhtmlPath}': {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}