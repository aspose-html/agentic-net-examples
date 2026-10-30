// Use inline expressions to calculate and display total price from JSON line item values.

using System;
using System.Collections.Generic;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML containing JSON line items
            string htmlContent = "<html><body>" +
                                 "<script type=\"application/json\" id=\"data\">" +
                                 "[{\"price\":10.5},{\"price\":20.0},{\"price\":5.25}]" +
                                 "</script>" +
                                 "</body></html>";

            // Load HTML using Aspose.Html
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Retrieve the JSON string from the script element
                Aspose.Html.HTMLElement scriptElement = (Aspose.Html.HTMLElement)document.GetElementById("data");
                string json = scriptElement.TextContent;

                // Deserialize JSON into a list of items
                List<LineItem> items = JsonSerializer.Deserialize<List<LineItem>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                // Calculate total price using inline expression
                double totalPrice = 0;
                foreach (var item in items)
                {
                    totalPrice += item.price;
                }

                // Display the result
                Console.WriteLine($"Total Price: {totalPrice}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private class LineItem
    {
        public double price { get; set; }
    }
}