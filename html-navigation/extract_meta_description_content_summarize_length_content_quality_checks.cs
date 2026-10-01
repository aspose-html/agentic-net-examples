// Extract all meta description content and summarize its length for content quality checks.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><meta name=\"description\" content=\"This is a sample description.\"><meta name=\"keywords\" content=\"sample, test\"><meta name=\"description\" content=\"Another description here.\"></head><body><p>Hello World</p></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html))
            {
                Aspose.Html.Collections.HTMLCollection metas = document.GetElementsByTagName("meta");
                int totalLength = 0;
                for (int i = 0; i < metas.Length; i++)
                {
                    Aspose.Html.HTMLElement meta = metas[i] as Aspose.Html.HTMLElement;
                    if (meta != null)
                    {
                        string name = meta.GetAttribute("name");
                        if (!string.IsNullOrEmpty(name) && name.Equals("description", StringComparison.OrdinalIgnoreCase))
                        {
                            string content = meta.GetAttribute("content");
                            if (!string.IsNullOrEmpty(content))
                            {
                                totalLength += content.Length;
                                Console.WriteLine($"Description: \"{content}\" (Length: {content.Length})");
                            }
                        }
                    }
                }
                Console.WriteLine($"Total description length: {totalLength}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}