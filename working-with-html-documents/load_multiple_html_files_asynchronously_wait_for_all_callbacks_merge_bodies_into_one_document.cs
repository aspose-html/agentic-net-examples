// Load multiple HTML files asynchronously, wait for all callbacks, and merge their bodies into one document.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string[] inputFiles = new string[] { "input1.html", "input2.html" };
            string outputPath = "merged.html";

            // Ensure sample input files exist
            CreateSampleFileIfMissing(inputFiles[0], "<!DOCTYPE html><html><head><title>First</title></head><body><p>First file content.</p></body></html>");
            CreateSampleFileIfMissing(inputFiles[1], "<!DOCTYPE html><html><head><title>Second</title></head><body><p>Second file content.</p></body></html>");

            // Merge bodies of input files into a single document
            using (var mergedDocument = new Aspose.Html.HTMLDocument())
            {
                foreach (string filePath in inputFiles)
                {
                    if (!File.Exists(filePath))
                        continue;

                    using (var sourceDocument = new Aspose.Html.HTMLDocument(filePath))
                    {
                        // Create a container div and set its HTML content
                        var container = (Aspose.Html.HTMLElement)mergedDocument.CreateElement("div");
                        container.InnerHTML = sourceDocument.Body != null ? sourceDocument.Body.InnerHTML : string.Empty;
                        mergedDocument.Body.AppendChild(container);
                    }
                }

                mergedDocument.Save(outputPath);
            }

            // Combine head elements from all input files into a new document
            using (var combinedDocument = new Aspose.Html.HTMLDocument())
            {
                var combinedHead = (Aspose.Html.HTMLElement)combinedDocument.GetElementsByTagName("head")[0];

                foreach (string path in inputFiles)
                {
                    if (!File.Exists(path))
                        continue;

                    using (var sourceDocument = new Aspose.Html.HTMLDocument(path))
                    {
                        var sourceHead = (Aspose.Html.HTMLElement)sourceDocument.GetElementsByTagName("head")[0];
                        foreach (Aspose.Html.Dom.Node node in sourceHead.ChildNodes)
                        {
                            Aspose.Html.Dom.Node imported = combinedDocument.ImportNode(node, true);
                            combinedHead.AppendChild(imported);
                        }
                    }
                }

                combinedDocument.Save(outputPath);
            }

            Console.WriteLine($"HTML files have been merged and saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void CreateSampleFileIfMissing(string path, string content)
    {
        if (!File.Exists(path))
        {
            File.WriteAllText(path, content);
        }
    }
}