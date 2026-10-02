// Identify external SVG files referenced by <img> tags and download them to local storage.

using System;
using System.IO;
using System.Net.Http;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string inputHtmlPath = "input.html";
            string outputHtmlPath = "output.html";
            string sampleHtml = @"<html><body><img src=""https://upload.wikimedia.org/wikipedia/commons/0/02/SVG_logo.svg"" alt=""logo""/></body></html>";
            File.WriteAllText(inputHtmlPath, sampleHtml);

            // Load HTML document
            HTMLDocument document = new HTMLDocument(inputHtmlPath);

            // Find all <img> elements
            Aspose.Html.Collections.NodeList imgElements = document.QuerySelectorAll("img");

            // Directory to store downloaded SVG files
            string downloadDir = "downloaded_svgs";
            Directory.CreateDirectory(downloadDir);

            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < imgElements.Length; i++)
                {
                    HTMLElement imgElement = (HTMLElement)imgElements[i];
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    if (src.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                    {
                        // Download SVG content
                        string svgContent = httpClient.GetStringAsync(src).Result;

                        // Determine local file name
                        string fileName = Path.GetFileName(new Uri(src).LocalPath);
                        if (string.IsNullOrEmpty(fileName))
                            fileName = $"image_{i}.svg";

                        string localPath = Path.Combine(downloadDir, fileName);
                        File.WriteAllText(localPath, svgContent);

                        // Update the src attribute to point to the local file
                        imgElement.SetAttribute("src", localPath);
                    }
                }
            }

            // Save the modified document
            document.Save(outputHtmlPath);
            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}