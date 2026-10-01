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

This is a paragraph with an inline link to [Google](https://www.google.com) and another link to [OpenAI](https://www.openai.com).";

            // Convert markdown to HTML using Aspose.Html
            var markdownStream = new MemoryStream(Encoding.UTF8.GetBytes(markdown));
            Aspose.Html.HTMLDocument htmlDoc = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownStream, "");

            Console.WriteLine("HTML output:");
            Console.WriteLine(htmlDoc.DocumentElement.OuterHTML);
            Console.WriteLine();

            // Transform inline markdown links to reference‑style links
            var references = new List<string>();
            int refIndex = 1;

            string transformed = Regex.Replace(markdown, @"\[(?<text>[^\]]+)\]\((?<url>[^)]+)\)", match =>
            {
                string text = match.Groups["text"].Value;
                string url = match.Groups["url"].Value;
                references.Add(url);
                string replacement = $"[{text}][{refIndex}]";
                refIndex++;
                return replacement;
            });

            var sb = new StringBuilder();
            sb.AppendLine(transformed);
            sb.AppendLine();
            for (int i = 0; i < references.Count; i++)
            {
                sb.AppendLine($"[{i + 1}]: {references[i]}");
            }

            string finalMarkdown = sb.ToString();

            Console.WriteLine("Transformed markdown with reference links:");
            Console.WriteLine(finalMarkdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}