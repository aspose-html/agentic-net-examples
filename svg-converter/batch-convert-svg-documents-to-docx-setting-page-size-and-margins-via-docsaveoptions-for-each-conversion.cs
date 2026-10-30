// Batch convert SVG documents to DOCX, setting page size and margins via DocSaveOptions for each conversion.

namespace Example
{
    class Program
    {
        static void Main()
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

                    Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);
                    Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

                    Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(595, 842);
                    Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(72, 72, 72, 72);
                    Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
                    options.PageSetup.AnyPage = page;

                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, docxPath);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}