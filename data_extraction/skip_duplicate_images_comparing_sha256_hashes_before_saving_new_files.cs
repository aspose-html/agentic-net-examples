// Skip duplicate images by comparing SHA256 hashes before saving new files.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Input HTML file path and output directory for extracted images
            string htmlPath = "input.html";
            string outputDir = "extracted_images";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Get all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            // Set to keep track of image hashes
            HashSet<string> seenHashes = new HashSet<string>();

            using (HttpClient httpClient = new HttpClient())
            using (SHA256 sha256 = SHA256.Create())
            {
                for (int i = 0; i < images.Length; i++)
                {
                    // Cast the element to HTMLElement to access attributes
                    Aspose.Html.HTMLElement imgElement = (Aspose.Html.HTMLElement)images[i];
                    string src = imgElement.GetAttribute("src");

                    if (string.IsNullOrWhiteSpace(src))
                        continue; // No source, skip

                    // Resolve relative URLs based on the HTML file location
                    Uri baseUri = new Uri(Path.GetFullPath(htmlPath));
                    Uri imageUri = new Uri(baseUri, src);
                    byte[] imageBytes;

                    // Download image data (supports http, https, file)
                    if (imageUri.Scheme == Uri.UriSchemeFile)
                    {
                        imageBytes = File.ReadAllBytes(imageUri.LocalPath);
                    }
                    else
                    {
                        imageBytes = httpClient.GetByteArrayAsync(imageUri).Result;
                    }

                    // Compute SHA256 hash
                    byte[] hashBytes = sha256.ComputeHash(imageBytes);
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                        sb.Append(b.ToString("x2"));
                    string hashString = sb.ToString();

                    // Skip if this image has already been saved
                    if (!seenHashes.Add(hashString))
                        continue;

                    // Determine a unique file name
                    string extension = Path.GetExtension(imageUri.AbsolutePath);
                    if (string.IsNullOrEmpty(extension))
                        extension = ".img";
                    string fileName = $"image_{i}{extension}";
                    string outputPath = Path.Combine(outputDir, fileName);

                    // Save the image file
                    File.WriteAllBytes(outputPath, imageBytes);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}