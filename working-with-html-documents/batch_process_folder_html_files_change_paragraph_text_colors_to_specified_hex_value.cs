// Batch process a folder of HTML files to change all paragraph text colors to a specified hex value.

using System;
using System.IO;
using System.Linq;

namespace BatchParagraphColor
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFolder = "InputHtml";
                string outputFolder = "OutputHtml";
                string colorHex = "#8b0000";

                Directory.CreateDirectory(inputFolder);
                Directory.CreateDirectory(outputFolder);

                foreach (string filePath in Directory.GetFiles(inputFolder, "*.html"))
                {
                    Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(filePath);
                    Aspose.Html.Dom.Element style = document.CreateElement("style");
                    style.TextContent = $"p {{ color: {colorHex}; }}";
                    Aspose.Html.Dom.Element head = document.GetElementsByTagName("head").First();
                    head.AppendChild(style);
                    string fileName = Path.GetFileName(filePath);
                    string outputPath = Path.Combine(outputFolder, fileName);
                    document.Save(outputPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}