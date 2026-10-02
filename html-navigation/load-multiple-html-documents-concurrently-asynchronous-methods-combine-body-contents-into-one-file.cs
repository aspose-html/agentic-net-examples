// Load multiple HTML documents concurrently using asynchronous methods and combine their body contents into one file.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Sample input files
            string[] paths = new string[]
            {
                "input1.html",
                "input2.html"
            };

            // Ensure sample files exist
            if (!File.Exists(paths[0]))
                File.WriteAllText(paths[0], "<html><body><p>Content from file 1</p></body></html>");
            if (!File.Exists(paths[1]))
                File.WriteAllText(paths[1], "<html><body><p>Content from file 2</p></body></html>");

            string outputPath = "combined.html";

            // Load documents concurrently
            Task<Aspose.Html.HTMLDocument>[] loadTasks = paths
                .Select(p => Task.Run(() => new Aspose.Html.HTMLDocument(p)))
                .ToArray();

            Aspose.Html.HTMLDocument[] sourceDocuments = await Task.WhenAll(loadTasks);

            // Create combined document
            using (Aspose.Html.HTMLDocument combinedDocument = new Aspose.Html.HTMLDocument())
            {
                var combinedBody = (Aspose.Html.HTMLElement)combinedDocument.GetElementsByTagName("body")[0];

                foreach (var sourceDocument in sourceDocuments)
                {
                    using (sourceDocument)
                    {
                        var sourceBody = (Aspose.Html.HTMLElement)sourceDocument.GetElementsByTagName("body")[0];
                        foreach (Aspose.Html.Dom.Node node in sourceBody.ChildNodes)
                        {
                            var imported = combinedDocument.ImportNode(node, true);
                            combinedBody.AppendChild(imported);
                        }
                    }
                }

                combinedDocument.Save(outputPath);
            }

            Console.WriteLine($"Combined document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}