// Generate a report summarizing all modifications made to a Markdown file, including counts of each change type.

namespace AsposeHtmlMarkdownReport
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define output directory and file paths
                string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output");
                System.IO.Directory.CreateDirectory(outputDir);
                string sourcePath = System.IO.Path.Combine(outputDir, "original.md");
                string modifiedPath = System.IO.Path.Combine(outputDir, "modified.md");
                string reportPath = System.IO.Path.Combine(outputDir, "modifications_report.csv");

                // Create original markdown content
                string originalContent = "# Sample Document\n\nThis is a paragraph.\n\n- Item 1\n- Item 2\n";
                System.IO.File.WriteAllText(sourcePath, originalContent);

                // Create modified markdown content
                string modifiedContent = "# Sample Document\n\nThis is an updated paragraph.\n\n- Item 1\n- Item 3\n- Item 4\n";
                System.IO.File.WriteAllText(modifiedPath, modifiedContent);

                // Load markdown files using Aspose.Html
                Aspose.Html.HTMLDocument originalDoc = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);
                Aspose.Html.HTMLDocument modifiedDoc = Aspose.Html.Converters.Converter.ConvertMarkdown(modifiedPath);

                // Save HTML versions (optional)
                string originalHtmlPath = System.IO.Path.Combine(outputDir, "original.html");
                string modifiedHtmlPath = System.IO.Path.Combine(outputDir, "modified.html");
                originalDoc.Save(originalHtmlPath);
                modifiedDoc.Save(modifiedHtmlPath);

                // Compute line‑based differences
                string[] originalLines = originalContent.Split(new[] { "\r\n", "\n" }, System.StringSplitOptions.None);
                string[] modifiedLines = modifiedContent.Split(new[] { "\r\n", "\n" }, System.StringSplitOptions.None);

                var added = new System.Collections.Generic.List<string>();
                var removed = new System.Collections.Generic.List<string>();
                var unchanged = new System.Collections.Generic.List<string>();

                var originalSet = new System.Collections.Generic.HashSet<string>(originalLines);
                var modifiedSet = new System.Collections.Generic.HashSet<string>(modifiedLines);

                foreach (string line in modifiedLines)
                {
                    if (!originalSet.Contains(line))
                        added.Add(line);
                    else
                        unchanged.Add(line);
                }

                foreach (string line in originalLines)
                {
                    if (!modifiedSet.Contains(line))
                        removed.Add(line);
                }

                int addedCount = added.Count;
                int removedCount = removed.Count;
                int unchangedCount = unchanged.Count;

                // Write CSV report
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(reportPath, false))
                {
                    writer.WriteLine("ChangeType,Count");
                    writer.WriteLine($"Added,{addedCount}");
                    writer.WriteLine($"Removed,{removedCount}");
                    writer.WriteLine($"Unchanged,{unchangedCount}");
                }

                System.Console.WriteLine("Modification report generated at: " + reportPath);
            }
            catch (System.Exception ex)
            {
                System.Console.Error.WriteLine("Error: " + ex.Message);
            }
        }
    }
}