// Batch convert HTML files to DOCX, preserving CSS styling and embedded images in the output.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputDocx";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    DocSaveOptions options = new DocSaveOptions();
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".docx");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                    Console.WriteLine($"Converted '{htmlPath}' to '{outputPath}'.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}