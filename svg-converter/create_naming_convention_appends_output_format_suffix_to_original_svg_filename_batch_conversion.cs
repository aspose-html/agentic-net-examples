// Create a naming convention that appends output format suffix to original SVG filename during batch conversion.

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
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputPdfs";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);

            foreach (string svgPath in svgFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(svgPath);
                string pdfPath = Path.Combine(outputFolder, fileName + ".pdf");

                PdfSaveOptions options = new PdfSaveOptions();
                options.PageSetup.AnyPage = new Page(options.PageSetup.AnyPage.Size, new Margin(0, 0, 0, 0));

                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, pdfPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}