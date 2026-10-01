// Validate that required fields like title and author exist in the YAML front‑matter block.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                string sampleContent = "---\ntitle: Sample Title\nauthor: John Doe\n---\n<html><body><h1>Hello World</h1></body></html>";
                File.WriteAllText(inputPath, sampleContent);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            string htmlContent = File.ReadAllText(inputPath);
            string frontMatter = "";
            if (htmlContent.StartsWith("---"))
            {
                int start = 3;
                int end = htmlContent.IndexOf("---", start);
                if (end != -1)
                {
                    frontMatter = htmlContent.Substring(start, end - start).Trim();
                }
            }

            bool hasTitle = false;
            bool hasAuthor = false;
            if (!string.IsNullOrEmpty(frontMatter))
            {
                string[] lines = frontMatter.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    string trimmed = line.Trim();
                    if (trimmed.StartsWith("title:", StringComparison.OrdinalIgnoreCase))
                    {
                        hasTitle = true;
                    }
                    else if (trimmed.StartsWith("author:", StringComparison.OrdinalIgnoreCase))
                    {
                        hasAuthor = true;
                    }
                }
            }

            if (hasTitle && hasAuthor)
            {
                Console.WriteLine("Front-matter validation passed: title and author are present.");
            }
            else
            {
                Console.WriteLine("Front-matter validation failed:");
                if (!hasTitle) Console.WriteLine("- Missing title");
                if (!hasAuthor) Console.WriteLine("- Missing author");
            }

            document.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}