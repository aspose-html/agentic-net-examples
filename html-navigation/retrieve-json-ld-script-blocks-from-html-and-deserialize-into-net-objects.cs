// Retrieve JSON‑LD script blocks from the HTML and deserialize them into .NET objects.

using System;
using System.Text.Json;
using System.Text.Json.Nodes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string html = @"<html><head><script type='application/ld+json'>{ ""@context"": ""http://schema.org"", ""@type"": ""Person"", ""name"": ""John Doe"", ""jobTitle"": ""Software Engineer"" }</script></head><body></body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection scriptElements = document.GetElementsByTagName("script");

                for (int i = 0; i < scriptElements.Length; i++)
                {
                    Aspose.Html.Dom.Element scriptElement = (Aspose.Html.Dom.Element)scriptElements[i];
                    string type = scriptElement.GetAttribute("type");
                    if (!string.IsNullOrEmpty(type) && type.Equals("application/ld+json", StringComparison.OrdinalIgnoreCase))
                    {
                        string json = scriptElement.TextContent;
                        if (!string.IsNullOrWhiteSpace(json))
                        {
                            try
                            {
                                JsonNode node = JsonNode.Parse(json);
                                Person person = JsonSerializer.Deserialize<Person>(json);
                                Console.WriteLine($"Name: {person?.Name}, JobTitle: {person?.JobTitle}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error parsing JSON-LD: {ex.Message}");
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}

public class Person
{
    public string Name { get; set; }
    public string JobTitle { get; set; }
}