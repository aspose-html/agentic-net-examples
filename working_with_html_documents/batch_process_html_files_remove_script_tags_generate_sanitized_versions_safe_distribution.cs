// Batch process HTML files, remove all script tags, and generate sanitized versions for safe distribution.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";
            Directory.CreateDirectory(outputFolder);
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                string inputPath = htmlPath;
                string outputPath = Path.Combine(outputFolder, Path.GetFileName(htmlPath));
                HTMLDocument document = new HTMLDocument(inputPath);
                var scripts = document.GetElementsByTagName("script");
                for (int i = scripts.Length - 1; i >= 0; i--)
                {
                    var script = scripts[i];
                    if (script.ParentNode != null)
                    {
                        script.ParentNode.RemoveChild(script);
                    }
                }
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}