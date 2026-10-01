// Apply attribute binding to set the src attribute of an img tag from JSON image URLs.

using System;
using System.IO;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputHtmlPath = "input.html";
            string outputHtmlPath = "output.html";
            string jsonPath = "images.json";

            // Create a minimal HTML file with an img tag if it does not exist
            if (!File.Exists(inputHtmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img id=\"img1\"/><img id=\"img2\"/></body></html>";
                File.WriteAllText(inputHtmlPath, htmlContent);
            }

            // Create a JSON file with image URLs if it does not exist
            if (!File.Exists(jsonPath))
            {
                string jsonContent = "{\"images\":[\"https://example.com/image1.png\",\"https://example.com/image2.png\"]}";
                File.WriteAllText(jsonPath, jsonContent);
            }

            // Parse JSON to get image URLs
            string[] imageUrls;
            using (FileStream jsonStream = File.OpenRead(jsonPath))
            {
                using (JsonDocument doc = JsonDocument.Parse(jsonStream))
                {
                    JsonElement root = doc.RootElement;
                    if (root.TryGetProperty("images", out JsonElement imagesElement) && imagesElement.ValueKind == JsonValueKind.Array)
                    {
                        int count = imagesElement.GetArrayLength();
                        imageUrls = new string[count];
                        int idx = 0;
                        foreach (JsonElement item in imagesElement.EnumerateArray())
                        {
                            imageUrls[idx++] = item.GetString();
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid JSON format: 'images' array not found.");
                    }
                }
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputHtmlPath);

            // Get all img elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Bind src attributes from JSON URLs
            for (int i = 0; i < images.Length && i < imageUrls.Length; i++)
            {
                Element imgElement = (Element)images[i];
                imgElement.SetAttribute("src", imageUrls[i]);
            }

            // Save the modified document
            document.Save(outputHtmlPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}