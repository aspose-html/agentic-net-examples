// Batch convert a set of MHTML files to PDF, applying a uniform 0.5‑inch margin on all sides.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputMhtml";
            string outputFolder = "OutputPdf";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string[] mhtmlFiles = Directory.GetFiles(inputFolder, "*.mhtml", SearchOption.TopDirectoryOnly);
            foreach (string mhtmlPath in mhtmlFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(mhtmlPath);
                string pdfPath = Path.Combine(outputFolder, fileName + ".pdf");

                using (FileStream stream = File.OpenRead(mhtmlPath))
                {
                    PdfSaveOptions options = new PdfSaveOptions();

                    Size pageSize = new Size(Length.FromInches(8.5), Length.FromInches(11));
                    Margin margin = new Margin(Length.FromInches(0.5), Length.FromInches(0.5), Length.FromInches(0.5), Length.FromInches(0.5));
                    Page page = new Page(pageSize, margin);
                    options.PageSetup.AnyPage = page;

                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, pdfPath);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}