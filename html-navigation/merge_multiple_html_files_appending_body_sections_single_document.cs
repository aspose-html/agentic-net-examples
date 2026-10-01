// Merge multiple HTML files by appending their body sections into a single document.

using System;
using System.IO;

namespace MergeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string[] inputFiles = new string[] { "input1.html", "input2.html" };
                string outputPath = "merged.html";

                // Create sample input files if they don't exist
                if (!File.Exists(inputFiles[0]))
                {
                    File.WriteAllText(inputFiles[0], "<html><body><h1>First Document</h1><p>Content of first.</p></body></html>");
                }
                if (!File.Exists(inputFiles[1]))
                {
                    File.WriteAllText(inputFiles[1], "<html><body><h1>Second Document</h1><p>Content of second.</p></body></html>");
                }

                using (Aspose.Html.HTMLDocument mergedDocument = new Aspose.Html.HTMLDocument())
                {
                    foreach (string filePath in inputFiles)
                    {
                        if (!File.Exists(filePath))
                            continue;

                        using (Aspose.Html.HTMLDocument sourceDocument = new Aspose.Html.HTMLDocument(filePath))
                        {
                            Aspose.Html.Dom.Element container = mergedDocument.CreateElement("div");
                            ((Aspose.Html.HTMLElement)container).InnerHTML = sourceDocument.Body != null ? sourceDocument.Body.InnerHTML : string.Empty;
                            mergedDocument.Body.AppendChild(container);
                        }
                    }

                    mergedDocument.Save(outputPath);
                }

                Console.WriteLine($"Merged HTML saved to {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}