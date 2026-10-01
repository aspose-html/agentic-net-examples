// Integrate MHTML to DOCX conversion into an ASP.NET MVC controller returning the file as a download.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "From: <test@example.com>\nSubject: Test\n\n<html><body><p>Sample</p></body></html>");
            }

            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                byte[] docxBytes = ConvertMhtmlToDocxBytes(inputStream);
                string outputPath = "output.docx";
                File.WriteAllBytes(outputPath, docxBytes);
                Console.WriteLine($"DOCX file saved to: {Path.GetFullPath(outputPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static byte[] ConvertMhtmlToDocxBytes(Stream inputStream)
    {
        string tempDocxPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".docx");
        Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
        Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, tempDocxPath);
        return File.ReadAllBytes(tempDocxPath);
    }
}