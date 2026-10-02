// Use a foreach expression to generate list items from a JSON array of navigation links.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample JSON array of navigation links
            string json = "[{\"href\":\"https://example.com/home\",\"text\":\"Home\"},{\"href\":\"https://example.com/about\",\"text\":\"About\"},{\"href\":\"https://example.com/contact\",\"text\":\"Contact\"}]";

            // Deserialize JSON to a list of NavLink objects
            List<NavLink> navLinks = JsonSerializer.Deserialize<List<NavLink>>(json);

            // Create an HTML document with a basic structure
            using Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(
                "<!DOCTYPE html><html><head><title>Navigation</title></head><body></body></html>",
                "about:blank");

            // Create a <ul> element and add it to the body
            Aspose.Html.HTMLElement ul = document.CreateElement("ul") as Aspose.Html.HTMLElement;
            document.Body.AppendChild(ul);

            // Generate <li> items from the JSON array using foreach
            foreach (NavLink link in navLinks)
            {
                Aspose.Html.HTMLElement li = document.CreateElement("li") as Aspose.Html.HTMLElement;
                Aspose.Html.HTMLElement a = document.CreateElement("a") as Aspose.Html.HTMLElement;
                a.SetAttribute("href", link.href);
                a.TextContent = link.text;
                li.AppendChild(a);
                ul.AppendChild(li);
            }

            // Output the resulting HTML
            Console.WriteLine(document.DocumentElement.OuterHTML);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Simple class representing a navigation link
    private class NavLink
    {
        public string href { get; set; }
        public string text { get; set; }
    }
}