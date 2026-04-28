// Compare two HTML documents and generate a diff report highlighting added and removed nodes.

using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

namespace HtmlDiffExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths to the original, modified HTML files and the diff report output
                string oldHtmlPath = "old.html";
                string newHtmlPath = "new.html";
                string diffReportPath = "diff.html";

                // Load the two HTML documents
                Aspose.Html.HTMLDocument oldDoc = new Aspose.Html.HTMLDocument(oldHtmlPath);
                Aspose.Html.HTMLDocument newDoc = new Aspose.Html.HTMLDocument(newHtmlPath);

                // Collect outer HTML of all elements in the old document
                var oldElements = oldDoc.GetElementsByTagName("*");
                HashSet<string> oldSet = new HashSet<string>();
                foreach (Aspose.Html.HTMLElement el in oldElements)
                {
                    oldSet.Add(el.OuterHTML);
                }

                // Collect outer HTML of all elements in the new document
                var newElements = newDoc.GetElementsByTagName("*");
                HashSet<string> newSet = new HashSet<string>();
                foreach (Aspose.Html.HTMLElement el in newElements)
                {
                    newSet.Add(el.OuterHTML);
                }

                // Determine added and removed nodes
                var added = newSet.Except(oldSet).ToList();
                var removed = oldSet.Except(newSet).ToList();

                // Build a simple HTML diff report
                string reportHtml = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"><title>HTML Diff Report</title></head><body>";
                reportHtml += "<h1>HTML Diff Report</h1>";

                reportHtml += "<h2>Added Nodes</h2>";
                if (added.Any())
                {
                    foreach (var node in added)
                    {
                        reportHtml += $"<div style=\"background:#e6ffe6;padding:5px;margin:5px;border:1px solid #00aa00;\">{System.Net.WebUtility.HtmlEncode(node)}</div>";
                    }
                }
                else
                {
                    reportHtml += "<p>None</p>";
                }

                reportHtml += "<h2>Removed Nodes</h2>";
                if (removed.Any())
                {
                    foreach (var node in removed)
                    {
                        reportHtml += $"<div style=\"background:#ffe6e6;padding:5px;margin:5px;border:1px solid #aa0000;\">{System.Net.WebUtility.HtmlEncode(node)}</div>";
                    }
                }
                else
                {
                    reportHtml += "<p>None</p>";
                }

                reportHtml += "</body></html>";

                // Create a new HTMLDocument from the report string and save it
                Aspose.Html.HTMLDocument reportDoc = new Aspose.Html.HTMLDocument(reportHtml, "");
                reportDoc.Save(diffReportPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}