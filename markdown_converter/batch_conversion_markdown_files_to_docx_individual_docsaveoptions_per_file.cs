// Implement batch conversion of Markdown files to DOCX with individual DocSaveOptions for each file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "InputMarkdown";
            string outputDir = "OutputDocx";

            Directory.CreateDirectory(outputDir);

            foreach (string sourcePath in Directory.GetFiles(inputDir, "*.md"))
            {
                string fileName = Path.GetFileNameWithoutExtension(sourcePath);
                string savePath = Path.Combine(outputDir, fileName + ".docx");

                HTMLDocument document = Converter.ConvertMarkdown(sourcePath);
                Converter.ConvertHTML(document, new DocSaveOptions(), savePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}