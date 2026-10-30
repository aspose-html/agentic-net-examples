// Save downloaded icons to a dedicated icons directory using a custom naming convention.

using System;
using System.IO;
using System.Net.Http;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input HTML page URL
            string pageUrl = "https://example.com";

            // Initialize Aspose.HTML configuration (optional)
            var configuration = new Aspose.Html.Configuration();

            // Load the HTML document from the URL
            var document = new Aspose.Html.HTMLDocument(pageUrl, configuration);

            // Prepare the output directory for icons
            string iconsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "icons");
            Directory.CreateDirectory(iconsDirectory);

            // Get all image elements in the document
            var images = document.Images; // HTMLCollection
            int savedCount = 0;

            using (var httpClient = new HttpClient())
            {
                for (int i = 0; i < images.Length; i++)
                {
                    var imgElement = images[i] as Aspose.Html.HTMLImageElement;
                    if (imgElement == null)
                        continue;

                    // Retrieve the image source URL
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    // Resolve relative URLs against the page URL
                    Uri imageUri;
                    if (!Uri.TryCreate(src, UriKind.Absolute, out imageUri))
                    {
                        imageUri = new Uri(new Uri(pageUrl), src);
                    }

                    // Filter for common icon file extensions
                    string extension = Path.GetExtension(imageUri.AbsolutePath).ToLowerInvariant();
                    if (extension != ".ico" && extension != ".png" && extension != ".jpg" && extension != ".jpeg" && extension != ".svg")
                        continue;

                    // Download the image data
                    byte[] imageData = httpClient.GetByteArrayAsync(imageUri).Result;

                    // Save using a custom naming convention: icon_{index}{extension}
                    string fileName = $"icon_{savedCount}{extension}";
                    string filePath = Path.Combine(iconsDirectory, fileName);
                    File.WriteAllBytes(filePath, imageData);

                    savedCount++;
                }
            }

            Console.WriteLine($"Downloaded {savedCount} icon(s) to \"{iconsDirectory}\".");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}