// Load multiple Markdown documents from a list and merge them into a single HTML output file.

class Program
{
    static void Main()
    {
        try
        {
            var markdownList = new System.Collections.Generic.List<string>
            {
                "# Title 1\nThis is the first markdown document.",
                "## Title 2\n* Item 1\n* Item 2"
            };

            var combinedMarkdown = string.Join("\n\n", markdownList);
            var markdownBytes = System.Text.Encoding.UTF8.GetBytes(combinedMarkdown);
            var stream = new System.IO.MemoryStream(markdownBytes);
            var mergedDocument = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, string.Empty);

            var outputPath = "merged_output.html";
            mergedDocument.Save(outputPath);

            System.Console.WriteLine(mergedDocument.DocumentElement.OuterHTML);
            System.Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}