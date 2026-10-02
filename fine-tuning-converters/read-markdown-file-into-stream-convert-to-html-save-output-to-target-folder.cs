// Read a Markdown file into a stream, convert to HTML, and save the output to a target folder.

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string markdownPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.md");
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output");
            System.IO.Directory.CreateDirectory(outputDir);

            if (!System.IO.File.Exists(markdownPath))
            {
                string sampleContent = "# Sample Markdown\n\nThis is a **markdown** file.";
                System.IO.File.WriteAllText(markdownPath, sampleContent);
            }

            byte[] markdownBytes = System.Text.Encoding.UTF8.GetBytes(System.IO.File.ReadAllText(markdownPath));
            using (var markdownStream = new System.IO.MemoryStream(markdownBytes))
            {
                using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownStream, "about:blank"))
                {
                    string htmlPath = System.IO.Path.Combine(outputDir, "sample.html");
                    document.Save(htmlPath);
                    System.Console.WriteLine("Conversion completed. HTML saved at " + htmlPath);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}