// Implement logging of source MHTML file size before conversion to assist in performance analysis.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.docx";

            if (!File.Exists(inputPath))
            {
                string minimalMhtml = "<html><body><h1>Sample MHTML</h1></body></html>";
                File.WriteAllText(inputPath, minimalMhtml);
            }

            long fileSize = new FileInfo(inputPath).Length;
            Console.WriteLine($"Source MHTML file size: {fileSize} bytes");

            using (Stream inputStream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputPath);
            }

            Console.WriteLine($"Conversion completed. Output saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}