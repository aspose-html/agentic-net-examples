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
            const string inputFilePath = "urls.txt";

            // Create a sample input file if it does not exist
            if (!File.Exists(inputFilePath))
            {
                File.WriteAllLines(inputFilePath, new string[]
                {
                    "https://example.com",
                    "https://www.w3.org"
                });
            }

            // Read URLs from the file
            string[] urlLines = File.ReadAllLines(inputFilePath);
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
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url))
                {
                    // Extract image resources
                    Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                    foreach (Aspose.Html.Dom.Element image in images)
                    {
                        string src = image.GetAttribute("src");
                        if (!string.IsNullOrEmpty(src))
                        {
                            Console.WriteLine($"  Image src: {src}");
                        }
                    }

                    // Extract script resources
                    Aspose.Html.Collections.HTMLCollection scripts = document.GetElementsByTagName("script");
                    foreach (Aspose.Html.Dom.Element script in scripts)
                    {
                        string src = script.GetAttribute("src");
                        if (!string.IsNullOrEmpty(src))
                        {
                            Console.WriteLine($"  Script src: {src}");
                        }
                    }

                    // Extract hyperlink resources
                    Aspose.Html.Collections.HTMLCollection links = document.GetElementsByTagName("a");
                    foreach (Aspose.Html.Dom.Element link in links)
                    {
                        string href = link.GetAttribute("href");
                        if (!string.IsNullOrEmpty(href))
                        {
                            Console.WriteLine($"  Link href: {href}");
                        }
                    }
                }
                pageIndex++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}