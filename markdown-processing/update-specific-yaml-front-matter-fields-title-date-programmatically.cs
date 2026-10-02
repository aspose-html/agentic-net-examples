// Update specific fields within the YAML front‑matter, such as title or date, programmatically.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                string sample = @"---
title: Old Title
date: 2023-01-01
---
<html><head><title>Sample</title></head><body><h1>Hello</h1></body></html>";
                File.WriteAllText(inputPath, sample);
            }

            string content = File.ReadAllText(inputPath);

            string updatedContent = content
                .Replace("title: Old Title", "title: New Title")
                .Replace("date: 2023-01-01", "date: 2024-12-31");

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(updatedContent, "about:blank");
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}