// Process a list of web page URLs from a text file and extract resources from each page.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string urlsFilePath = "urls.txt";

            // Create a sample URLs file if it does not exist
            if (!File.Exists(urlsFilePath))
            {
                File.WriteAllLines(urlsFilePath, new string[] { "https://example.com" });
            }

            // Read URLs from the file
            string[] urlLines = File.ReadAllLines(urlsFilePath);
            List<string> urls = new List<string>();
            foreach (string line in urlLines)
            {
                string trimmed = line.Trim();
                if (!string.IsNullOrEmpty(trimmed))
                {
                    urls.Add(trimmed);
                }
            }

            int pageIndex = 1;
            foreach (string url in urls)
            {
                Console.WriteLine($"Processing URL #{pageIndex}: {url}");
                using (HTMLDocument document = new HTMLDocument(url))
                {
                    // Extract image sources
                    HTMLCollection images = document.GetElementsByTagName("img");
                    foreach (Element image in images)
                    {
                        string src = image.GetAttribute("src");
                        if (!string.IsNullOrEmpty(src))
                        {
                            Console.WriteLine($"  Image: {src}");
                        }
                    }

                    // Extract script sources
                    HTMLCollection scripts = document.GetElementsByTagName("script");
                    foreach (Element script in scripts)
                    {
                        string src = script.GetAttribute("src");
                        if (!string.IsNullOrEmpty(src))
                        {
                            Console.WriteLine($"  Script: {src}");
                        }
                    }

                    // Extract hyperlink references
                    HTMLCollection links = document.GetElementsByTagName("a");
                    foreach (Element link in links)
                    {
                        string href = link.GetAttribute("href");
                        if (!string.IsNullOrEmpty(href))
                        {
                            string text = link.TextContent != null ? link.TextContent.Trim() : string.Empty;
                            Console.WriteLine($"  Link: href=\"{href}\", text=\"{text}\"");
                        }
                    }
                }
                pageIndex++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}