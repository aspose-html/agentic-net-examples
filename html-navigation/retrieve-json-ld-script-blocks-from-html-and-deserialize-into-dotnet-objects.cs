// Retrieve JSON‑LD script blocks from the HTML and deserialize them into .NET objects.

using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

public class JsonLdPerson
{
    [JsonPropertyName("@type")]
    public string? Type { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string htmlContent = @"
                <html>
                    <head><title>Sample</title></head>
                    <body>
                        <script type=""application/ld+json"">
                        {
                            ""@type"": ""Person"",
                            ""name"": ""John Doe""
                        }
                        </script>
                        <script type=""application/ld+json"">
                        {
                            ""@type"": ""Organization"",
                            ""name"": ""Acme Corp""
                        }
                        </script>
                    </body>
                </html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                HTMLCollection scriptElements = document.GetElementsByTagName("script");
                for (int i = 0; i < scriptElements.Length; i++)
                {
                    Element scriptElement = (Element)scriptElements[i];
                    string typeAttr = scriptElement.GetAttribute("type");
                    if (string.Equals(typeAttr, "application/ld+json", StringComparison.OrdinalIgnoreCase))
                    {
                        string json = scriptElement.TextContent?.Trim() ?? string.Empty;
                        if (!string.IsNullOrEmpty(json))
                        {
                            // Parse as JsonNode (optional)
                            JsonNode node = JsonNode.Parse(json);
                            Console.WriteLine("Parsed JSON-LD node:");
                            Console.WriteLine(node.ToJsonString());

                            // Deserialize to .NET object
                            JsonLdPerson? person = JsonSerializer.Deserialize<JsonLdPerson>(json);
                            if (person != null)
                            {
                                Console.WriteLine($"Deserialized object: Type={person.Type}, Name={person.Name}");
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}