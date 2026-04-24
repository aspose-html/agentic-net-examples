// Save each extracted icon to the output folder with appropriate .ico extension.

using System;
using System.IO;
using System.Net.Http;
using Aspose.Html;
using Aspose.Html.Services;

namespace IconExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths (replace with actual paths as needed)
                string htmlPath = "input.html";
                string outputFolder = "output";

                // Ensure output directory exists
                Directory.CreateDirectory(outputFolder);

                // Create Aspose.HTML configuration (default)
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

                // Load the HTML document using the configuration
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration);

                // Retrieve all <link> elements
                var linkElements = document.GetElementsByTagName("link");

                // HttpClient for downloading icon files
                using HttpClient httpClient = new HttpClient();

                // Base URI of the HTML file to resolve relative URLs
                Uri baseUri = new Uri(Path.GetFullPath(htmlPath));

                foreach (var link in linkElements)
                {
                    // Check if the link element defines an icon
                    string rel = link.GetAttribute("rel");
                    if (!string.IsNullOrEmpty(rel) && rel.Contains("icon", StringComparison.OrdinalIgnoreCase))
                    {
                        string href = link.GetAttribute("href");
                        if (string.IsNullOrEmpty(href))
                            continue;

                        // Resolve the icon URL relative to the HTML file location
                        Uri iconUri = new Uri(baseUri, href);

                        // Download the icon data
                        byte[] iconData = httpClient.GetByteArrayAsync(iconUri).GetAwaiter().GetResult();

                        // Determine output file name with .ico extension
                        string fileName = Path.GetFileName(iconUri.LocalPath);
                        if (!fileName.EndsWith(".ico", StringComparison.OrdinalIgnoreCase))
                            fileName = Path.ChangeExtension(fileName, ".ico");

                        string outputPath = Path.Combine(outputFolder, fileName);

                        // Save the icon to the output folder
                        File.WriteAllBytes(outputPath, iconData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}