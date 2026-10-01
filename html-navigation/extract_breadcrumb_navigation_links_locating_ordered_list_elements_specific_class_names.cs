// Extract breadcrumb navigation links by locating ordered list elements with specific class names.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><ol class=\"breadcrumb\"><li><a href=\"/home\">Home</a></li><li><a href=\"/products\">Products</a></li><li>Current</li></ol></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, ""))
            {
                var breadcrumbLists = document.QuerySelectorAll("ol.breadcrumb");
                var results = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>();
                foreach (Aspose.Html.HTMLElement list in breadcrumbLists)
                {
                    var links = list.QuerySelectorAll("a");
                    foreach (Aspose.Html.HTMLElement link in links)
                    {
                        string href = link.GetAttribute("href");
                        string text = link.TextContent != null ? link.TextContent.Trim() : string.Empty;
                        if (!string.IsNullOrEmpty(href))
                        {
                            var dict = new System.Collections.Generic.Dictionary<string, string>();
                            dict["href"] = href;
                            dict["text"] = text;
                            results.Add(dict);
                        }
                    }
                }
                string json = System.Text.Json.JsonSerializer.Serialize(results, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                System.Console.WriteLine(json);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}