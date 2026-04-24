// Provide an option to overwrite existing files or skip them based on a user‑defined flag.

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
            string inputFolder = args.Length > 0 ? args[0] : "InputHtml";
            string outputFolder = args.Length > 1 ? args[1] : "OutputPdf";
            bool overwrite = args.Length > 2 && bool.Parse(args[2]);

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
            foreach (string htmlPath in htmlFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(htmlPath);
                string pdfPath = Path.Combine(outputFolder, fileName + ".pdf");

                if (File.Exists(pdfPath) && !overwrite)
                    continue;

                Converter.ConvertHTML(htmlPath, new PdfSaveOptions(), pdfPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}