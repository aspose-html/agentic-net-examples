// Batch process a folder of HTML files to change all paragraph text colors to a specified hex value.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputHtml";
            string colorHex = "#FF5733";

            System.IO.Directory.CreateDirectory(outputFolder);
            string[] files = System.IO.Directory.GetFiles(inputFolder, "*.html");

            foreach (string filePath in files)
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(filePath);
                Aspose.Html.Collections.NodeList paragraphs = document.QuerySelectorAll("p");

                foreach (Aspose.Html.HTMLElement paragraph in paragraphs)
                {
                    paragraph.Style.Color = colorHex;
                }

                string fileName = System.IO.Path.GetFileName(filePath);
                string outputPath = System.IO.Path.Combine(outputFolder, fileName);
                document.Save(outputPath);
            }

            Console.WriteLine("Processing completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}