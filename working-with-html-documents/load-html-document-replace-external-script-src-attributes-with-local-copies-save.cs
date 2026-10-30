// Load an HTML document, replace all external script src attributes with local copies, and save.

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
            // Prepare sample input HTML file
            string inputPath = "input.html";
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
    <script src=""https://code.jquery.com/jquery-3.6.0.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/lodash.js/4.17.21/lodash.min.js""></script>
</head>
<body>
    <h1>Hello World</h1>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            string outputPath = "output.html";
            string scriptsFolder = "local_scripts";
            Directory.CreateDirectory(scriptsFolder);

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Get all script elements
            HTMLCollection scriptElements = document.GetElementsByTagName("script");

            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < scriptElements.Length; i++)
                {
                    Element scriptElement = (Element)scriptElements[i];
                    string src = scriptElement.GetAttribute("src");
                    if (!string.IsNullOrEmpty(src))
                    {
                        // Download the external script
                        string scriptContent = httpClient.GetStringAsync(src).Result;

                        // Determine a local file name
                        string fileName = Path.GetFileName(new Uri(src).AbsolutePath);
                        if (string.IsNullOrEmpty(fileName))
                        {
                            fileName = $"script_{i}.js";
                        }
                        string localPath = Path.Combine(scriptsFolder, fileName);

                        // Save the script locally
                        File.WriteAllText(localPath, scriptContent);

                        // Update the src attribute to point to the local copy
                        // Use relative path for portability
                        string relativePath = Path.Combine(scriptsFolder, fileName).Replace("\\", "/");
                        scriptElement.SetAttribute("src", relativePath);

                        Console.WriteLine($"Replaced external script '{src}' with local copy '{relativePath}'.");
                    }
                }
            }

            // Save the modified document
            document.Save(outputPath);
            Console.WriteLine($"Document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}