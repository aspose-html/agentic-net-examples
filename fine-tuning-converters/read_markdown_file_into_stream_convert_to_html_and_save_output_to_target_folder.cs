// Read a Markdown file into a stream, convert to HTML, and save the output to a target folder.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output");
            System.IO.Directory.CreateDirectory(outputDir);

            string sourcePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.md");
            if (!System.IO.File.Exists(sourcePath))
            {
                string sampleMarkdown = "# Sample Markdown\nThis is a **markdown** file converted to HTML.";
                System.IO.File.WriteAllText(sourcePath, sampleMarkdown);
            }

            byte[] markdownBytes = System.IO.File.ReadAllBytes(sourcePath);
            using (var stream = new System.IO.MemoryStream(markdownBytes))
            {
                string baseUri = "file:///" + sourcePath.Replace("\\", "/");
                HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, baseUri);
                string outputPath = System.IO.Path.Combine(outputDir, "sample.html");
                document.Save(outputPath);
                Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}