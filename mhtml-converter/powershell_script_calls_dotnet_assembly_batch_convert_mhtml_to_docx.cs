// Develop a PowerShell script that calls the .NET assembly to batch convert MHTML files to DOCX.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = args.Length > 0 ? args[0] : "InputMhtml";
            string outputFolder = args.Length > 1 ? args[1] : "OutputDocx";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample MHTML file if none exist
            if (Directory.GetFiles(inputFolder, "*.mhtml").Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.mhtml");
                File.WriteAllText(samplePath, "<html><body><p>Sample MHTML content</p></body></html>");
            }

            foreach (string mhtmlPath in Directory.GetFiles(inputFolder, "*.mhtml"))
            {
                using (FileStream stream = File.OpenRead(mhtmlPath))
                {
                    byte[] docxBytes = ConvertMhtmlToDocxBytes(stream);
                    string outputFileName = Path.GetFileNameWithoutExtension(mhtmlPath) + ".docx";
                    string outputPath = Path.Combine(outputFolder, outputFileName);
                    File.WriteAllBytes(outputPath, docxBytes);
                    Console.WriteLine($"Converted '{mhtmlPath}' to '{outputPath}'.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static byte[] ConvertMhtmlToDocxBytes(Stream inputStream)
    {
        string tempDocxPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".docx");
        Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
        Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, tempDocxPath);
        byte[] result = File.ReadAllBytes(tempDocxPath);
        try { File.Delete(tempDocxPath); } catch { }
        return result;
    }
}