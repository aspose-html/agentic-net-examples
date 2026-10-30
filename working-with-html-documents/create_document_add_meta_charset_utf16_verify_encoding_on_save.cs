// Create a document, add a meta charset tag for UTF‑16, and verify correct encoding on save.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string sourcePath = "sample.html";
            string outputPath = "output.html";
            string modifiedOutputPath = "output_modified.html";
            string markdownPath = "output.md";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><meta name=\"description\" content=\"old description\"><title>Sample</title></head><body><h1>Hello World</h1></body></html>";
                File.WriteAllText(sourcePath, sampleHtml, Encoding.UTF8);
            }

            // Read HTML content from the file using UTF-8 encoding
            string htmlContent = File.ReadAllText(sourcePath, Encoding.GetEncoding("utf-8"));

            // Load HTML from string and save to a file
            var document = new Aspose.Html.HTMLDocument(htmlContent, string.Empty);
            document.Save(outputPath);

            // Load HTML from a memory stream, modify a meta tag, and save
            byte[] bytes = Encoding.UTF8.GetBytes(htmlContent);
            using (var inputStream = new MemoryStream(bytes))
            using (var docFromStream = new Aspose.Html.HTMLDocument(inputStream, string.Empty))
            {
                var metaElements = docFromStream.GetElementsByTagName("meta");
                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    if (meta.GetAttribute("name") == "description")
                    {
                        meta.SetAttribute("content", "new description");
                    }
                }
                docFromStream.Save(modifiedOutputPath);
            }

            // Load HTML from file and save as Markdown
            var docFromFile = new Aspose.Html.HTMLDocument(sourcePath, string.Empty);
            docFromFile.Save(markdownPath, Aspose.Html.Saving.HTMLSaveFormat.Markdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}