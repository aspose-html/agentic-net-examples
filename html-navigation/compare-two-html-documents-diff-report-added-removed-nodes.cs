// Compare two HTML documents and generate a diff report highlighting added and removed nodes.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string inputPath1 = "doc1.html";
            string inputPath2 = "doc2.html";
            string outputPath = "diff_report.txt";

            // Create sample HTML files if they do not exist
            if (!File.Exists(inputPath1))
            {
                File.WriteAllText(inputPath1,
@"<html>
<head><title>Document 1</title></head>
<body>
<p>Paragraph A</p>
<div>Div 1</div>
</body>
</html>");
            }

            if (!File.Exists(inputPath2))
            {
                File.WriteAllText(inputPath2,
@"<html>
<head><title>Document 2</title></head>
<body>
<p>Paragraph A</p>
<p>Paragraph B</p>
<div>Div 1</div>
<span>New Span</span>
</body>
</html>");
            }

            // Load documents
            HTMLDocument document1 = new HTMLDocument(inputPath1);
            HTMLDocument document2 = new HTMLDocument(inputPath2);

            // Collect outer HTML of all elements in each document
            HashSet<string> set1 = new HashSet<string>();
            HashSet<string> set2 = new HashSet<string>();

            Aspose.Html.Collections.NodeList nodes1 = document1.QuerySelectorAll("*");
            foreach (Node node in nodes1)
            {
                HTMLElement element = node as HTMLElement;
                if (element != null)
                {
                    set1.Add(element.OuterHTML);
                }
            }

            Aspose.Html.Collections.NodeList nodes2 = document2.QuerySelectorAll("*");
            foreach (Node node in nodes2)
            {
                HTMLElement element = node as HTMLElement;
                if (element != null)
                {
                    set2.Add(element.OuterHTML);
                }
            }

            // Determine added and removed nodes
            List<string> added = new List<string>();
            foreach (string html in set2)
            {
                if (!set1.Contains(html))
                {
                    added.Add(html);
                }
            }

            List<string> removed = new List<string>();
            foreach (string html in set1)
            {
                if (!set2.Contains(html))
                {
                    removed.Add(html);
                }
            }

            // Write diff report
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                writer.WriteLine("=== Added Nodes ===");
                foreach (string html in added)
                {
                    writer.WriteLine(html);
                }

                writer.WriteLine();
                writer.WriteLine("=== Removed Nodes ===");
                foreach (string html in removed)
                {
                    writer.WriteLine(html);
                }
            }

            Console.WriteLine("Diff report generated at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}