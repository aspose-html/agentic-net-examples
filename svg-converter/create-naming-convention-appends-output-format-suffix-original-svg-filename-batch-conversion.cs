// Create a naming convention that appends output format suffix to original SVG filename during batch conversion.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputSvgs";
            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            string[] svgFiles = System.IO.Directory.GetFiles(inputFolder, "*.svg", System.IO.SearchOption.TopDirectoryOnly);
            foreach (string svgPath in svgFiles)
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(svgPath);
                string pdfPath = System.IO.Path.Combine(outputFolder, fileName + "_pdf.pdf");

                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    options.PageSetup.AnyPage.Size,
                    new Aspose.Html.Drawing.Margin(10, 10, 10, 10));

                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, pdfPath);
                Console.WriteLine($"Converted {System.IO.Path.GetFileName(svgPath)} to {System.IO.Path.GetFileName(pdfPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}