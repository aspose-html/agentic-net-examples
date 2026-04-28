// Retrieve JSON‑LD script blocks from the HTML and deserialize them into .NET objects.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using System.Text.Json;

namespace JsonLdExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the HTML file containing JSON‑LD script blocks
                string htmlPath = "input.html";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Get all <script> elements
                HTMLCollection scriptElements = document.GetElementsByTagName("script");

                // Iterate through script elements and process those with type="application/ld+json"
                for (int i = 0; i < scriptElements.Length; i++)
                {
                    // Cast the node to an Element to access attributes and text
                    Element scriptElement = (Element)scriptElements[i];

                    // Check the script type
                    string type = scriptElement.GetAttribute("type");
                    if (!string.IsNullOrEmpty(type) && type.Equals("application/ld+json", StringComparison.OrdinalIgnoreCase))
                    {
                        // Retrieve the JSON‑LD content
                        string jsonLd = scriptElement.TextContent?.Trim();

                        if (!string.IsNullOrEmpty(jsonLd))
                        {
                            // Deserialize the JSON‑LD into a JsonElement (or any custom class)
                            JsonElement data = JsonSerializer.Deserialize<JsonElement>(jsonLd);

                            // Output the deserialized object (for demonstration)
                            Console.WriteLine(data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}