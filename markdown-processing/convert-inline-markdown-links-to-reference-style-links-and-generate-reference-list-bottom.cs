// Convert inline Markdown links to reference‑style links and generate a reference list at the bottom.

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown with inline links
            string markdown = @"# Sample Document

This is a paragraph with an [inline link](https://example.com) and another [link](https://github.com).

Another line with a [different link](https://dotnet.microsoft.com).";

            // Convert inline links to reference‑style links
            var references = new List<string>();
            int refIndex = 1;
            string processed = Regex.Replace(markdown, @"\[(?<text>[^\]]+)\]\((?<url>[^)]+)\)", m =>
            {
                string text = m.Groups["text"].Value;
                string url = m.Groups["url"].Value;
                references.Add(url);
                string replacement = $"[{text}][{refIndex}]";
                refIndex++;
                return replacement;
            });

            // Append reference list at the bottom
            var sb = new StringBuilder();
            sb.AppendLine(processed);
            sb.AppendLine();
            for (int i = 0; i < references.Count; i++)
            {
                sb.AppendLine($"[{i + 1}]: {references[i]}");
            }
            string finalMarkdown = sb.ToString();

            // Convert Markdown to HTML using Aspose.HTML
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(finalMarkdown)))
            {
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "about:blank");

                // Save HTML to file
                string outputPath = "output.html";
                document.Save(outputPath);

                // Output result to console
                Console.WriteLine(document.DocumentElement.OuterHTML);
                Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}