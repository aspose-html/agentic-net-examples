// Convert all heading texts to title case while keeping their existing hash level markers.

using System;
using System.IO;
using System.Text;
using System.Globalization;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputMarkdown";
            string outputFolder = "OutputHtml";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create a sample markdown file if none exist
            if (Directory.GetFiles(inputFolder, "*.md").Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.md");
                File.WriteAllText(samplePath, "# sample heading\n## another heading\nRegular text line.");
            }

            foreach (string mdPath in Directory.GetFiles(inputFolder, "*.md"))
            {
                string markdown = File.ReadAllText(mdPath);
                var sb = new StringBuilder();

                foreach (string rawLine in markdown.Split('\n'))
                {
                    string line = rawLine.TrimEnd('\r');
                    int hashCount = 0;
                    while (hashCount < line.Length && line[hashCount] == '#')
                        hashCount++;

                    if (hashCount > 0 && hashCount < line.Length && char.IsWhiteSpace(line[hashCount]))
                    {
                        string afterHashes = line.Substring(hashCount).TrimStart();
                        string titleCased = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(afterHashes.ToLower());
                        string newLine = new string('#', hashCount) + " " + titleCased;
                        sb.AppendLine(newLine);
                    }
                    else
                    {
                        sb.AppendLine(line);
                    }
                }

                string processedMarkdown = sb.ToString();

                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(processedMarkdown)))
                {
                    Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "about:blank");
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(mdPath) + ".html");
                    document.Save(outputPath);
                    Console.WriteLine("Converted: " + outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}