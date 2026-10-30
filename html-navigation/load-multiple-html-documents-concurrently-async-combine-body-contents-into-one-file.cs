// Load multiple HTML documents concurrently using asynchronous methods and combine their body contents into one file.

using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string inputPath1 = "input1.html";
            string inputPath2 = "input2.html";
            string outputPath = "combined.html";

            // Create minimal sample HTML files if they do not exist
            if (!File.Exists(inputPath1))
            {
                File.WriteAllText(inputPath1, "<!DOCTYPE html><html><head><title>Doc1</title></head><body><p>Content from document 1.</p></body></html>");
            }
            if (!File.Exists(inputPath2))
            {
                File.WriteAllText(inputPath2, "<!DOCTYPE html><html><head><title>Doc2</title></head><body><div>Content from document 2.</div></body></html>");
            }

            // List of source file paths
            string[] paths = new string[] { inputPath1, inputPath2 };

            // Load documents concurrently
            List<Task<HTMLDocument>> loadTasks = new List<Task<HTMLDocument>>();
            foreach (string path in paths)
            {
                loadTasks.Add(Task.Run(() => new HTMLDocument(path)));
            }

            HTMLDocument[] sourceDocuments = await Task.WhenAll(loadTasks);

            // Create combined document
            using (HTMLDocument combinedDocument = new HTMLDocument())
            {
                // Get the <body> element of the combined document
                HTMLElement combinedBody = (HTMLElement)combinedDocument.GetElementsByTagName("body")[0];

                // Append body contents from each source document
                foreach (HTMLDocument sourceDocument in sourceDocuments)
                {
                    using (sourceDocument)
                    {
                        HTMLElement sourceBody = (HTMLElement)sourceDocument.GetElementsByTagName("body")[0];
                        Aspose.Html.Collections.NodeList childNodes = sourceBody.ChildNodes;
                        for (int i = 0; i < childNodes.Length; i++)
                        {
                            Node node = childNodes[i];
                            Node imported = combinedDocument.ImportNode(node, true);
                            combinedBody.AppendChild(imported);
                        }
                    }
                }

                // Save the combined document
                combinedDocument.Save(outputPath);
            }

            Console.WriteLine("Combined HTML saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}