// Append a list of tags to the YAML front‑matter based on extracted heading keywords.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputYaml";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");

                HashSet<string> tags = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                for (int i = 0; i < headings.Length; i++)
                {
                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)headings[i];
                    string text = element.TextContent.Trim();

                    string[] words = text.Split(new char[] { ' ', ',', ';', ':', '-', '_', '.' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        string lower = word.ToLowerInvariant();
                        if (lower.Length > 2)
                            tags.Add(lower);
                    }
                }

                StringBuilder yaml = new StringBuilder();
                yaml.AppendLine("---");
                yaml.AppendLine($"title: {Path.GetFileNameWithoutExtension(htmlPath)}");
                yaml.Append("tags: [");
                bool first = true;
                foreach (string tag in tags)
                {
                    if (!first) yaml.Append(", ");
                    yaml.Append($"\"{tag}\"");
                    first = false;
                }
                yaml.AppendLine("]");
                yaml.AppendLine("---");

                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".md");
                File.WriteAllText(outputPath, yaml.ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}