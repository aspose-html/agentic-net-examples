// Batch process a list of SVG files to PDF, applying AdjustToWidestPage to each conversion.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputPdfs";

            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            string[] svgFiles = System.IO.Directory.GetFiles(inputFolder, "*.svg", System.IO.SearchOption.TopDirectoryOnly);

            foreach (string svgPath in svgFiles)
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(svgPath);
                string pdfPath = System.IO.Path.Combine(outputFolder, fileName + ".pdf");

                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    options.PageSetup.AnyPage.Size,
                    new Aspose.Html.Drawing.Margin(20, 20, 20, 20));

                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, pdfPath);
                Console.WriteLine($"Converted: {svgPath} -> {pdfPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}