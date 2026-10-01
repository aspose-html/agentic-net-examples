// Load multiple HTML documents concurrently using asynchronous methods and combine their body contents into one file.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string[] paths = new string[]
            {
                "input1.html",
                "input2.html"
            };
            string outputPath = "combined.html";

            // Create minimal sample HTML files if they do not exist
            if (!File.Exists(paths[0]))
            {
                File.WriteAllText(paths[0], "<!DOCTYPE html><html><head><title>Doc1</title></head><body><p>Content from document 1.</p></body></html>");
            }
            if (!File.Exists(paths[1]))
            {
                File.WriteAllText(paths[1], "<!DOCTYPE html><html><head><title>Doc2</title></head><body><p>Content from document 2.</p></body></html>");
            }

            // Create the combined document
            using (HTMLDocument combinedDocument = new HTMLDocument())
            {
                // Get the <body> element of the combined document
                HTMLElement combinedBody = (HTMLElement)combinedDocument.GetElementsByTagName("body")[0];

                // Load source documents concurrently
                List<Task<HTMLDocument>> loadTasks = new List<Task<HTMLDocument>>();
                foreach (string path in paths)
                {
                    loadTasks.Add(Task.Run(() => new HTMLDocument(path)));
                }

                HTMLDocument[] sourceDocuments = await Task.WhenAll(loadTasks);

                // Merge body contents
                foreach (HTMLDocument sourceDocument in sourceDocuments)
                {
                    HTMLElement sourceBody = (HTMLElement)sourceDocument.GetElementsByTagName("body")[0];
                    foreach (Node node in sourceBody.ChildNodes)
                    {
                        Node imported = combinedDocument.ImportNode(node, true);
                        combinedBody.AppendChild(imported);
                    }
                    sourceDocument.Dispose();
                }

                // Save the combined document
                combinedDocument.Save(outputPath);
            }

            Console.WriteLine("Combined HTML saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}