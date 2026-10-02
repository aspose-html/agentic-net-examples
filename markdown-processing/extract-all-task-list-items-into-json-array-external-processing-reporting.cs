// Extract all task list items into a JSON array for external processing or reporting.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><body><ul><li><input type=\"checkbox\"/>Task 1</li><li><input type=\"checkbox\" checked/>Task 2</li><li>Not a task</li></ul></body></html>";
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank", configuration))
            {
                NodeList listItems = document.QuerySelectorAll("li");
                List<string> tasks = new List<string>();
                for (int i = 0; i < listItems.Length; i++)
                {
                    HTMLElement li = listItems[i] as HTMLElement;
                    if (li != null)
                    {
                        NodeList inputs = li.QuerySelectorAll("input[type=checkbox]");
                        if (inputs.Length > 0)
                        {
                            string text = li.TextContent.Trim();
                            tasks.Add(text);
                        }
                    }
                }
                string json = JsonSerializer.Serialize(tasks);
                Console.WriteLine(json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}