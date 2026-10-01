// Load multiple HTML documents asynchronously, merge their head sections, and produce a combined document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample input files
            string inputFile1 = "sample1.html";
            string inputFile2 = "sample2.html";
            CreateSampleFileIfMissing(inputFile1, "<!DOCTYPE html><html><head><title>Sample 1</title></head><body><p>Content 1</p></body></html>");
            CreateSampleFileIfMissing(inputFile2, "<!DOCTYPE html><html><head><title>Sample 2</title></head><body><p>Content 2</p></body></html>");

            string[] inputFiles = new string[] { inputFile1, inputFile2 };
            string combinedOutputPath = "combined_head.html";
            string mergedOutputPath = "merged_body.html";

            // ---------- Combine <head> elements ----------
            using (Aspose.Html.HTMLDocument combinedDocument = new Aspose.Html.HTMLDocument())
            {
                // Get the <head> element of the combined document
                Aspose.Html.HTMLElement combinedHead = (Aspose.Html.HTMLElement)combinedDocument.GetElementsByTagName("head")[0];

                foreach (string path in inputFiles)
                {
                    if (!File.Exists(path))
                        continue;

                    using (Aspose.Html.HTMLDocument sourceDocument = new Aspose.Html.HTMLDocument(path))
                    {
                        Aspose.Html.HTMLElement sourceHead = (Aspose.Html.HTMLElement)sourceDocument.GetElementsByTagName("head")[0];

                        foreach (Aspose.Html.Dom.Node node in sourceHead.ChildNodes)
                        {
                            Aspose.Html.Dom.Node imported = combinedDocument.ImportNode(node, true);
                            combinedHead.AppendChild(imported);
                        }
                    }
                }

                combinedDocument.Save(combinedOutputPath);
                Console.WriteLine($"Combined head saved to: {combinedOutputPath}");
            }

            // ---------- Merge body contents into <div> containers ----------
            using (Aspose.Html.HTMLDocument mergedDocument = new Aspose.Html.HTMLDocument())
            {
                foreach (string filePath in inputFiles)
                {
                    if (!File.Exists(filePath))
                        continue;

                    using (Aspose.Html.HTMLDocument sourceDocument = new Aspose.Html.HTMLDocument(filePath))
                    {
                        // Create a <div> element and set its inner HTML
                        Aspose.Html.HTMLElement container = (Aspose.Html.HTMLElement)mergedDocument.CreateElement("div");
                        container.InnerHTML = sourceDocument.Body != null ? sourceDocument.Body.InnerHTML : string.Empty;

                        // Append the container to the merged document's body
                        mergedDocument.Body.AppendChild(container);
                    }
                }

                mergedDocument.Save(mergedOutputPath);
                Console.WriteLine($"Merged body saved to: {mergedOutputPath}");
            }
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