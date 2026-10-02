// Batch convert SVG documents to DOCX, setting page size and margins via DocSaveOptions for each conversion.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputDocs";

            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            string[] svgFiles = System.IO.Directory.GetFiles(inputFolder, "*.svg", System.IO.SearchOption.TopDirectoryOnly);

            foreach (string svgPath in svgFiles)
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(svgPath);
                string docxPath = System.IO.Path.Combine(outputFolder, fileName + ".docx");

                Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

                Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(595, 842); // A4 size in points
                Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(50, 50, 50, 50); // margins in points
                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
                options.PageSetup.AnyPage = page;

                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, docxPath);
            }

            System.Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}