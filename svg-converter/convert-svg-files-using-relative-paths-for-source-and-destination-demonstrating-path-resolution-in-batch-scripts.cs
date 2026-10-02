// Convert SVG files using relative paths for source and destination, demonstrating path resolution in batch scripts.

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputFolder = "./svg";
                string outputFolder = "./pdf";

                if (!System.IO.Directory.Exists(outputFolder))
                    System.IO.Directory.CreateDirectory(outputFolder);
                if (!System.IO.Directory.Exists(inputFolder))
                    System.IO.Directory.CreateDirectory(inputFolder);

                // Create a sample SVG if none exist
                string[] existingSvgs = System.IO.Directory.GetFiles(inputFolder, "*.svg", System.IO.SearchOption.TopDirectoryOnly);
                if (existingSvgs.Length == 0)
                {
                    string sampleSvgPath = System.IO.Path.Combine(inputFolder, "sample.svg");
                    System.IO.File.WriteAllText(sampleSvgPath, "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"200\"><rect width=\"200\" height=\"200\" fill=\"red\"/></svg>");
                }

                string[] svgFiles = System.IO.Directory.GetFiles(inputFolder, "*.svg", System.IO.SearchOption.TopDirectoryOnly);
                foreach (string svgPath in svgFiles)
                {
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(svgPath);
                    string pdfPath = System.IO.Path.Combine(outputFolder, fileName + ".pdf");

                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                        new Aspose.Html.Drawing.Size(595, 842), // A4 size in points
                        new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

                    Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, pdfPath);
                    System.Console.WriteLine($"Converted '{System.IO.Path.GetFileName(svgPath)}' to '{System.IO.Path.GetFileName(pdfPath)}'");
                }
            }
            catch (System.Exception ex)
            {
                System.Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}