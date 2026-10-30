// Load multiple HTML files asynchronously, wait for all callbacks, and merge their bodies into one document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML files
            string[] inputFiles = new string[] { "input1.html", "input2.html" };

            // Create minimal sample files if they do not exist
            foreach (string filePath in inputFiles)
            {
                if (!System.IO.File.Exists(filePath))
                {
                    string sampleContent = "<html><head><title>Sample</title></head><body><p>Content from " + filePath + "</p></body></html>";
                    System.IO.File.WriteAllText(filePath, sampleContent);
                }
            }

            // Load documents asynchronously
            var loadTasks = new System.Collections.Generic.List<System.Threading.Tasks.Task<Aspose.Html.HTMLDocument>>();
            foreach (string filePath in inputFiles)
            {
                var task = System.Threading.Tasks.Task.Run(() =>
                {
                    return new Aspose.Html.HTMLDocument(filePath);
                });
                loadTasks.Add(task);
            }

            System.Threading.Tasks.Task.WaitAll(loadTasks.ToArray());

            // Merge bodies into a single document
            using (Aspose.Html.HTMLDocument mergedDocument = new Aspose.Html.HTMLDocument())
            {
                foreach (var loadTask in loadTasks)
                {
                    using (Aspose.Html.HTMLDocument sourceDocument = loadTask.Result)
                    {
                        Aspose.Html.Dom.Element container = mergedDocument.CreateElement("div");
                        Aspose.Html.HTMLElement htmlContainer = (Aspose.Html.HTMLElement)container;
                        htmlContainer.InnerHTML = sourceDocument.Body != null ? sourceDocument.Body.InnerHTML : string.Empty;
                        mergedDocument.Body.AppendChild(htmlContainer);
                    }
                }

                string outputPath = "merged.html";
                mergedDocument.Save(outputPath);
                Console.WriteLine("Merged document saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}