// Convert an unordered list of items into an ordered list while preserving list hierarchy.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";
            if (!System.IO.Directory.Exists(outputFolder)) System.IO.Directory.CreateDirectory(outputFolder);
            if (!System.IO.Directory.Exists(inputFolder)) System.IO.Directory.CreateDirectory(inputFolder);

            string inputPath = System.IO.Path.Combine(inputFolder, "sample.html");
            string outputPath = System.IO.Path.Combine(outputFolder, "sample_converted.html");

            if (!System.IO.File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><body><ul><li>Item 1<ul><li>Subitem 1</li></ul></li><li>Item 2</li></ul></body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Collections.NodeList uls = document.QuerySelectorAll("ul");

            for (int i = uls.Length - 1; i >= 0; i--)
            {
                Aspose.Html.HTMLElement ul = (Aspose.Html.HTMLElement)uls[i];
                Aspose.Html.HTMLElement ol = (Aspose.Html.HTMLElement)document.CreateElement("ol");

                while (ul.FirstChild != null)
                {
                    ol.AppendChild(ul.FirstChild);
                }

                Aspose.Html.Dom.Node parent = ul.ParentNode;
                parent.ReplaceChild(ol, ul);
            }

            document.Save(outputPath);
            System.Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}