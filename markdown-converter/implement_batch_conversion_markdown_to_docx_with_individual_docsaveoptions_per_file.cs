// Implement batch conversion of Markdown files to DOCX with individual DocSaveOptions for each file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            var markdownFiles = new[]
            {
                new { Name = "doc1.md", Content = "# Document 1\nThis is the first document.", Output = "doc1-output.docx" },
                new { Name = "doc2.md", Content = "# Document 2\nThis is the second document.", Output = "doc2-output.docx" }
            };

            foreach (var item in markdownFiles)
            {
                string sourcePath = Path.Combine(outputDir, item.Name);
                File.WriteAllText(sourcePath, item.Content);

                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

                Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

                string savePath = Path.Combine(outputDir, item.Output);
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}