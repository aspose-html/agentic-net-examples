// Batch convert SVG documents to DOCX, setting page size and margins via DocSaveOptions for each conversion.

using System;
using System.IO;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

namespace BatchSvgToDocx
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define input and output directories
                string inputFolder = "InputSvgs";
                string outputFolder = "OutputDocx";

                // Ensure the output directory exists
                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);

                // Get all SVG files in the input directory
                string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);

                foreach (string svgPath in svgFiles)
                {
                    // Determine output DOCX file path
                    string fileName = Path.GetFileNameWithoutExtension(svgPath);
                    string docxPath = Path.Combine(outputFolder, fileName + ".docx");

                    // Load the SVG document
                    using (SVGDocument document = new SVGDocument(svgPath))
                    {
                        // Create conversion options
                        DocSaveOptions options = new DocSaveOptions();

                        // Define page size (500x500) and margins (top:30, right:10, bottom:10, left:10)
                        Size size = new Size(500, 500);
                        Margin margin = new Margin(30, 10, 10, 10);
                        Page page = new Page(size, margin);

                        // Apply the page setup to the options
                        options.PageSetup.AnyPage = page;

                        // Perform the conversion
                        Converter.ConvertSVG(document, options, docxPath);
                    }
                }

                Console.WriteLine("Batch conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}