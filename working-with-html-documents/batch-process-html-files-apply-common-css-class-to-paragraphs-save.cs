// Batch process a list of HTML files, apply a common CSS class to all paragraphs, and save.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputHtml";

            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<html><body><p>Paragraph 1</p><p>Paragraph 2</p></body></html>");
            }

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.Collections.NodeList paragraphs = document.QuerySelectorAll("p");
                foreach (Aspose.Html.HTMLElement paragraph in paragraphs)
                {
                    paragraph.SetAttribute("class", "myClass");
                }
                string outputPath = Path.Combine(outputFolder, Path.GetFileName(htmlPath));
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