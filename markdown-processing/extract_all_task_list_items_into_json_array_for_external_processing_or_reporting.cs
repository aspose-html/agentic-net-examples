// Extract all task list items into a JSON array for external processing or reporting.

using System;
using System.Collections.Generic;
using System.Text.Json;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><body><ul>" +
                          "<li><input type=\"checkbox\"/> Task one</li>" +
                          "<li><input type=\"checkbox\" checked/> Task two</li>" +
                          "<li>Regular item</li>" +
                          "</ul></body></html>";

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank", configuration))
            {
                var listItems = document.GetElementsByTagName("li");
                var tasks = new List<string>();

                foreach (Aspose.Html.Dom.Element element in listItems)
                {
                    var inputs = element.GetElementsByTagName("input");
                    bool isTask = false;

                    foreach (Aspose.Html.Dom.Element input in inputs)
                    {
                        Aspose.Html.HTMLElement inputElem = input as Aspose.Html.HTMLElement;
                        if (inputElem != null && inputElem.GetAttribute("type") == "checkbox")
                        {
                            isTask = true;
                            break;
                        }
                    }

                    if (isTask)
                    {
                        string text = element.TextContent.Trim();
                        tasks.Add(text);
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