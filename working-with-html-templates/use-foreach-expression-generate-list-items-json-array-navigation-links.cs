// Use a foreach expression to generate list items from a JSON array of navigation links.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // JSON array of navigation links
            string json = "[{\"href\":\"https://example.com\",\"text\":\"Home\"},{\"href\":\"https://example.com/about\",\"text\":\"About\"}]";

            // Parse JSON
            System.Text.Json.JsonDocument jsonDoc = System.Text.Json.JsonDocument.Parse(json);
            System.Text.Json.JsonElement root = jsonDoc.RootElement;

            // Create an HTML document with a placeholder <ul id='nav'>
            string htmlContent = "<html><body><ul id='nav'></ul></body></html>";
            using (Aspose.Html.HTMLDocument htmlDoc = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Dom.Element ul = (Aspose.Html.Dom.Element)htmlDoc.GetElementById("nav");

                // Generate list items from JSON using foreach
                foreach (System.Text.Json.JsonElement link in root.EnumerateArray())
                {
                    string href = link.GetProperty("href").GetString();
                    string text = link.GetProperty("text").GetString();

                    Aspose.Html.Dom.Element li = (Aspose.Html.Dom.Element)htmlDoc.CreateElement("li");
                    Aspose.Html.Dom.Element a = (Aspose.Html.Dom.Element)htmlDoc.CreateElement("a");
                    a.SetAttribute("href", href);
                    a.TextContent = text;

                    li.AppendChild(a);
                    ul.AppendChild(li);
                }

                // Save the resulting HTML
                string outputPath = "navigation.html";
                htmlDoc.Save(outputPath);
                Console.WriteLine($"HTML file saved to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}