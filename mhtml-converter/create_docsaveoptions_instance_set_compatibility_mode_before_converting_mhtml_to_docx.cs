// Create a DocSaveOptions instance to set compatibility mode before converting MHTML to DOCX.

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
            string inputPath = "sample.mhtml";
            string outputPath = "output.docx";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><p>Sample content</p></body></html>");
            }

            using (FileStream stream = File.OpenRead(inputPath))
            {
                DocSaveOptions saveOptions = new DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, saveOptions, outputPath);
            }

            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}