// Load multiple HTML documents asynchronously, merge their head sections, and produce a combined document.

using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string[] inputFiles = new string[] { "sample1.html", "sample2.html" };
            string outputPath = "combined.html";

            // Create minimal sample HTML files if they do not exist
            if (!File.Exists(inputFiles[0]))
            {
                File.WriteAllText(inputFiles[0],
                    "<!DOCTYPE html><html><head><title>Sample 1</title><meta charset=\"utf-8\"></head><body><p>Content 1</p></body></html>");
            }
            if (!File.Exists(inputFiles[1]))
            {
                File.WriteAllText(inputFiles[1],
                    "<!DOCTYPE html><html><head><title>Sample 2</title><meta name=\"viewport\" content=\"width=device-width\"></head><body><p>Content 2</p></body></html>");
            }

            // Create the combined document
            using (HTMLDocument combinedDocument = new HTMLDocument())
            {
                HTMLElement combinedHead = (HTMLElement)combinedDocument.GetElementsByTagName("head")[0];

                foreach (string path in inputFiles)
                {
                    if (!File.Exists(path))
                        continue;

                    // Load each source document asynchronously
                    HTMLDocument sourceDocument = await Task.Run(() => new HTMLDocument(path));
                    using (sourceDocument)
                    {
                        HTMLElement sourceHead = (HTMLElement)sourceDocument.GetElementsByTagName("head")[0];
                        foreach (Node node in sourceHead.ChildNodes)
                        {
                            Node imported = combinedDocument.ImportNode(node, true);
                            combinedHead.AppendChild(imported);
                        }
                    }
                }

                // Save the combined document
                combinedDocument.Save(outputPath);
            }

            Console.WriteLine("Combined document saved to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}