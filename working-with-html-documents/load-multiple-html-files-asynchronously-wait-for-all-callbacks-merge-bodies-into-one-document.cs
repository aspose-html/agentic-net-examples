// Load multiple HTML files asynchronously, wait for all callbacks, and merge their bodies into one document.

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
            string[] inputFiles = new string[] { "input1.html", "input2.html" };
            string outputPath = "merged.html";

            // Create sample input files if they do not exist
            if (!File.Exists(inputFiles[0]))
                File.WriteAllText(inputFiles[0], "<html><body><p>First file content.</p></body></html>");
            if (!File.Exists(inputFiles[1]))
                File.WriteAllText(inputFiles[1], "<html><body><p>Second file content.</p></body></html>");

            using (var mergedDocument = new Aspose.Html.HTMLDocument())
            {
                var loadTasks = inputFiles.Select(async filePath =>
                {
                    if (!File.Exists(filePath))
                        return;

                    using (var sourceDocument = new Aspose.Html.HTMLDocument(filePath))
                    {
                        var container = mergedDocument.CreateElement("div");
                        var htmlContainer = (Aspose.Html.HTMLElement)container;
                        var body = sourceDocument.Body;
                        htmlContainer.InnerHTML = body != null ? body.InnerHTML : string.Empty;
                        mergedDocument.Body.AppendChild(container);
                    }
                }).ToArray();

                await Task.WhenAll(loadTasks);

                mergedDocument.Save(outputPath);
                Console.WriteLine($"Merged document saved to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}