// Use a foreach expression to generate list items from a JSON array of navigation links.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string json = "[{\"href\":\"/home\",\"text\":\"Home\"},{\"href\":\"/about\",\"text\":\"About\"},{\"href\":\"/contact\",\"text\":\"Contact\"}]";

            var navLinks = new System.Collections.Generic.List<NavLink>();
            using (var jsonDoc = System.Text.Json.JsonDocument.Parse(json))
            {
                foreach (var element in jsonDoc.RootElement.EnumerateArray())
                {
                    string href = element.GetProperty("href").GetString();
                    string text = element.GetProperty("text").GetString();
                    navLinks.Add(new NavLink { Href = href, Text = text });
                }
            }

            var document = new Aspose.Html.HTMLDocument();
            var ul = (Aspose.Html.HTMLElement)document.CreateElement("ul");

            foreach (var link in navLinks)
            {
                var li = (Aspose.Html.HTMLElement)document.CreateElement("li");
                var a = (Aspose.Html.HTMLElement)document.CreateElement("a");
                a.SetAttribute("href", link.Href);
                a.TextContent = link.Text;
                li.AppendChild(a);
                ul.AppendChild(li);
            }

            document.Body.AppendChild(ul);
            document.Save("navigation.html");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }

    private class NavLink
    {
        public string Href { get; set; }
        public string Text { get; set; }
    }
}