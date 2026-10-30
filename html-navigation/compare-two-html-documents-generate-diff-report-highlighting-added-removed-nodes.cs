// Compare two HTML documents and generate a diff report highlighting added and removed nodes.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath1 = "sample1.html";
            string inputPath2 = "sample2.html";
            string outputPath = "diff_report.txt";

            // Create sample HTML files if they do not exist
            if (!File.Exists(inputPath1))
            {
                File.WriteAllText(inputPath1, "<html><body><p>First paragraph.</p><!-- Comment --></body></html>");
            }
            if (!File.Exists(inputPath2))
            {
                File.WriteAllText(inputPath2, "<html><body><p>First paragraph.</p><p>Second paragraph added.</p></body></html>");
            }

            // Load documents
            HTMLDocument document1 = new HTMLDocument(inputPath1);
            HTMLDocument document2 = new HTMLDocument(inputPath2);

            // Remove comments from both documents
            RemoveComments(document1.DocumentElement);
            RemoveComments(document2.DocumentElement);

            // Collect element signatures (outer HTML) from each document
            HashSet<string> elementsDoc1 = new HashSet<string>();
            HashSet<string> elementsDoc2 = new HashSet<string>();

            Aspose.Html.Collections.NodeList allElements1 = document1.QuerySelectorAll("*");
            foreach (HTMLElement element in allElements1)
            {
                elementsDoc1.Add(element.OuterHTML);
            }

            Aspose.Html.Collections.NodeList allElements2 = document2.QuerySelectorAll("*");
            foreach (HTMLElement element in allElements2)
            {
                elementsDoc2.Add(element.OuterHTML);
            }

            // Determine added and removed nodes
            List<string> added = new List<string>();
            List<string> removed = new List<string>();

            foreach (string el in elementsDoc2)
            {
                if (!elementsDoc1.Contains(el))
                {
                    added.Add(el);
                }
            }

            foreach (string el in elementsDoc1)
            {
                if (!elementsDoc2.Contains(el))
                {
                    removed.Add(el);
                }
            }

            // Write diff report
            using (StreamWriter writer = new StreamWriter(outputPath, false))
            {
                writer.WriteLine("=== Diff Report ===");
                writer.WriteLine();
                writer.WriteLine("Added nodes:");
                foreach (string a in added)
                {
                    writer.WriteLine(a);
                }
                writer.WriteLine();
                writer.WriteLine("Removed nodes:");
                foreach (string r in removed)
                {
                    writer.WriteLine(r);
                }
            }

            Console.WriteLine("Diff report generated at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void RemoveComments(Node node)
    {
        Node child = node.FirstChild;
        while (child != null)
        {
            Node next = child.NextSibling;
            if (child.NodeName == "#comment")
            {
                node.RemoveChild(child);
            }
            else
            {
                RemoveComments(child);
            }
            child = next;
        }
    }
}