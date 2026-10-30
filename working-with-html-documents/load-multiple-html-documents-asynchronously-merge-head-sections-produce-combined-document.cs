// Load multiple HTML documents asynchronously, merge their head sections, and produce a combined document.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Input HTML file paths
            string[] inputFiles = new string[]
            {
                "input1.html",
                "input2.html"
            };

            // Ensure sample input files exist
            foreach (string file in inputFiles)
            {
                if (!File.Exists(file))
                {
                    string sampleContent = $"<html><head><title>{Path.GetFileNameWithoutExtension(file)}</title></head><body><p>Content of {file}</p></body></html>";
                    File.WriteAllText(file, sampleContent);
                }
            }

            // Load documents asynchronously
            Task<Aspose.Html.HTMLDocument>[] loadTasks = inputFiles
                .Select(path => Task.Run(() => new Aspose.Html.HTMLDocument(path)))
                .ToArray();

            await Task.WhenAll(loadTasks);
            Aspose.Html.HTMLDocument[] sourceDocuments = loadTasks.Select(t => t.Result).ToArray();

            // Create combined document
            using (Aspose.Html.HTMLDocument combinedDocument = new Aspose.Html.HTMLDocument())
            {
                Aspose.Html.HTMLElement combinedHead = (Aspose.Html.HTMLElement)combinedDocument.GetElementsByTagName("head")[0];

                // Merge head sections
                foreach (Aspose.Html.HTMLDocument sourceDocument in sourceDocuments)
                {
                    Aspose.Html.HTMLElement sourceHead = (Aspose.Html.HTMLElement)sourceDocument.GetElementsByTagName("head")[0];
                    foreach (Aspose.Html.Dom.Node node in sourceHead.ChildNodes)
                    {
                        Aspose.Html.Dom.Node imported = combinedDocument.ImportNode(node, true);
                        combinedHead.AppendChild(imported);
                    }
                }

                // Save combined document
                string outputPath = "combined.html";
                combinedDocument.Save(outputPath);
                Console.WriteLine($"Combined document saved to: {outputPath}");
            }

            // Dispose source documents
            foreach (Aspose.Html.HTMLDocument doc in sourceDocuments)
            {
                doc.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}