// Extract all meta viewport values and verify they contain width=device‑width for responsive design.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head>" +
                          "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">" +
                          "<meta name=\"description\" content=\"test\">" +
                          "<meta name=\"viewport\" content=\"initial-scale=1\">" +
                          "</head><body></body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection metas = document.GetElementsByTagName("meta");
                bool anyViewport = false;

                for (int i = 0; i < metas.Length; i++)
                {
                    Aspose.Html.HTMLElement meta = (Aspose.Html.HTMLElement)metas[i];
                    string name = meta.GetAttribute("name");
                    if (!string.IsNullOrEmpty(name) && name.Equals("viewport", StringComparison.OrdinalIgnoreCase))
                    {
                        anyViewport = true;
                        string content = meta.GetAttribute("content");
                        bool hasWidth = !string.IsNullOrEmpty(content) && content.Contains("width=device-width");
                        Console.WriteLine($"Viewport meta content: \"{content}\" - Contains width=device-width: {hasWidth}");
                    }
                }

                if (!anyViewport)
                {
                    Console.WriteLine("No viewport meta tags found.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}