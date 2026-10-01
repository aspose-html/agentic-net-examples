// Retrieve JSON‑LD script blocks from the HTML and deserialize them into .NET objects.

public class Program
{
    public static void Main()
    {
        try
        {
            string html = "<html><head><script type=\"application/ld+json\">{ \"@context\": \"http://schema.org\", \"@type\": \"Person\", \"name\": \"John Doe\" }</script></head><body></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html);
            Aspose.Html.Collections.HTMLCollection scriptElements = document.GetElementsByTagName("script");
            for (int i = 0; i < scriptElements.Length; i++)
            {
                Aspose.Html.Dom.Element scriptElement = (Aspose.Html.Dom.Element)scriptElements[i];
                string typeAttr = scriptElement.GetAttribute("type");
                if (typeAttr != null && typeAttr.Equals("application/ld+json", System.StringComparison.OrdinalIgnoreCase))
                {
                    string json = scriptElement.TextContent;
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        try
                        {
                            System.Text.Json.Nodes.JsonNode node = System.Text.Json.Nodes.JsonNode.Parse(json);
                            System.Console.WriteLine(node.ToJsonString());
                        }
                        catch (System.Exception ex)
                        {
                            System.Console.WriteLine("Failed to parse JSON-LD: " + ex.Message);
                        }
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}