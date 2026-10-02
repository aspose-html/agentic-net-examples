// Batch convert a set of MHTML files to PDF, applying a uniform 0.5‑inch margin on all sides.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputMhtml";
            string outputFolder = "OutputPdf";

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

                    // Define page size (A4) and 0.5‑inch margins (36 points)
                    Size pageSize = new Size(Length.FromInches(8.27), Length.FromInches(11.69));
                    Margin margin = new Margin(36, 36, 36, 36);
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