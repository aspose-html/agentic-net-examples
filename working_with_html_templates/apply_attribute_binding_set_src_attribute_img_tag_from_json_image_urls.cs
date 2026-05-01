// Apply attribute binding to set the src attribute of an img tag from JSON image URLs.

using System;
using System.Collections.Generic;
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
            string inputPath = "input.html";
            string outputPath = "output.html";
            string jsonPath = "images.json";

            // Load JSON image URLs
            string jsonContent = File.ReadAllText(jsonPath);
            List<string> imageUrls = JsonSerializer.Deserialize<List<string>>(jsonContent);

            // Load HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Get all img elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Bind src attributes from JSON URLs
            for (int i = 0; i < images.Length && i < imageUrls.Count; i++)
            {
                Element imageElement = (Element)images[i];
                imageElement.SetAttribute("src", imageUrls[i]);
            }

            // Save modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}