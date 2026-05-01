// Use a foreach expression to generate list items from a JSON array of navigation links.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string json = "[{\"title\":\"Home\",\"url\":\"/\"},{\"title\":\"About\",\"url\":\"/about\"},{\"title\":\"Contact\",\"url\":\"/contact\"}]";
                var links = JsonSerializer.Deserialize<List<NavLink>>(json);
                using var document = new Aspose.Html.HTMLDocument();
                var ul = document.CreateElement("ul");
                document.Body.AppendChild(ul);
                foreach (var link in links)
                {
                    var li = document.CreateElement("li");
                    var a = document.CreateElement("a");
                    a.SetAttribute("href", link.Url);
                    a.TextContent = link.Title;
                    li.AppendChild(a);
                    ul.AppendChild(li);
                }
                document.Save("navigation.html");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        class NavLink
        {
            public string Title { get; set; }
            public string Url { get; set; }
        }
    }
}