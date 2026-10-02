// Convert existing Markdown tables into plain text representations while preserving column alignment.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.md";
            string savePath = "output.html";

            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath,
@"# Sample Table

| Name    | Age | City     |
|---------|-----|----------|
| Alice   | 30  | New York |
| Bob     | 25  | London   |
| Charlie | 35  | Paris    |");
            }

            Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath, savePath);

            Console.WriteLine($"Markdown converted to HTML and saved at: {savePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}