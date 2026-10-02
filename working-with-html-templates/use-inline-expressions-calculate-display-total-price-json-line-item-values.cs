// Use inline expressions to calculate and display total price from JSON line item values.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body><script id='data' type='application/json'>[{\"price\":10.5},{\"price\":20.0},{\"price\":5.75}]</script></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Dom.Element scriptElement = document.GetElementById("data");
                if (scriptElement == null)
                {
                    Console.WriteLine("JSON data element not found.");
                    return;
                }

                string json = scriptElement.TextContent;
                List<Item> items = JsonSerializer.Deserialize<List<Item>>(json);
                double total = 0;
                foreach (Item item in items)
                {
                    total += item.Price;
                }

                Console.WriteLine($"Total price: {total}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private class Item
    {
        public double Price { get; set; }
    }
}