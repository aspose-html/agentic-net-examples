// Compare two HTML documents and generate a diff report highlighting added and removed nodes.

using System;
using System.IO;
using System.Drawing;
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
            // Prepare sample input files
            string inputPath1 = "input1.html";
            string inputPath2 = "input2.html";
            string outputPath = "diff_report.html";

            if (!File.Exists(inputPath1))
            {
                File.WriteAllText(inputPath1,
@"<!DOCTYPE html>
<html>
<head><title>Doc1</title></head>
<body>
    <p id='p1'>Paragraph 1</p>
    <div id='div1'>Div 1</div>
    <span id='span1'>Span 1</span>
</body>
</html>");
            }

            if (!File.Exists(inputPath2))
            {
                File.WriteAllText(inputPath2,
@"<!DOCTYPE html>
<html>
<head><title>Doc2</title></head>
<body>
    <p id='p1'>Paragraph 1</p>
    <div id='div2'>Div 2 (new)</div>
    <span id='span1'>Span 1</span>
    <a id='link1' href='#'>New Link</a>
</body>
</html>");
            }

            // Load documents
            Aspose.Html.HTMLDocument doc1 = new Aspose.Html.HTMLDocument(inputPath1);
            Aspose.Html.HTMLDocument doc2 = new Aspose.Html.HTMLDocument(inputPath2);

            // Remove comments from both documents
            RemoveComments(doc1.DocumentElement);
            RemoveComments(doc2.DocumentElement);

            // Use doc2 as the base for the diff report
            Aspose.Html.HTMLDocument reportDoc = new Aspose.Html.HTMLDocument(inputPath2);

            // Highlight added nodes (present in doc2 but not in doc1)
            Aspose.Html.Collections.NodeList addedElements = doc2.QuerySelectorAll("*[id]");
            foreach (Aspose.Html.HTMLElement element in addedElements)
            {
                string id = element.GetAttribute("id");
                if (string.IsNullOrEmpty(id))
                    continue;

                Aspose.Html.HTMLElement counterpart = (Aspose.Html.HTMLElement)doc1.GetElementById(id);
                if (counterpart == null)
                {
                    // Highlight in the report document
                    Aspose.Html.HTMLElement reportElement = (Aspose.Html.HTMLElement)reportDoc.GetElementById(id);
                    if (reportElement != null)
                    {
                        reportElement.Style.BackgroundColor = System.Drawing.Color.LightGreen.Name;
                    }
                }
            }

            // Collect removed node IDs (present in doc1 but not in doc2)
            var removedIds = new List<string>();
            Aspose.Html.Collections.NodeList removedCandidates = doc1.QuerySelectorAll("*[id]");
            foreach (Aspose.Html.HTMLElement element in removedCandidates)
            {
                string id = element.GetAttribute("id");
                if (string.IsNullOrEmpty(id))
                    continue;

                Aspose.Html.HTMLElement counterpart = (Aspose.Html.HTMLElement)doc2.GetElementById(id);
                if (counterpart == null)
                {
                    removedIds.Add(id);
                }
            }

            // Insert a section at the top of the report for removed nodes
            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)reportDoc.Body;
            Aspose.Html.HTMLElement header = (Aspose.Html.HTMLElement)reportDoc.CreateElement("h1");
            header.InnerHTML = "Diff Report";
            body.InsertBefore(header, body.FirstChild);

            if (removedIds.Count > 0)
            {
                Aspose.Html.HTMLElement removedDiv = (Aspose.Html.HTMLElement)reportDoc.CreateElement("div");
                Aspose.Html.HTMLElement removedHeader = (Aspose.Html.HTMLElement)reportDoc.CreateElement("h2");
                removedHeader.InnerHTML = "Removed Nodes";
                removedDiv.AppendChild(removedHeader);

                Aspose.Html.HTMLElement ul = (Aspose.Html.HTMLElement)reportDoc.CreateElement("ul");
                foreach (string id in removedIds)
                {
                    Aspose.Html.HTMLElement li = (Aspose.Html.HTMLElement)reportDoc.CreateElement("li");
                    li.InnerHTML = $"Element with id '{id}' was removed.";
                    ul.AppendChild(li);
                }
                removedDiv.AppendChild(ul);
                body.InsertBefore(removedDiv, header.NextSibling);
            }

            // Save the diff report
            reportDoc.Save(outputPath);
            Console.WriteLine($"Diff report generated: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void RemoveComments(Aspose.Html.Dom.Node node)
    {
        var child = node.FirstChild;
        while (child != null)
        {
            var next = child.NextSibling;
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