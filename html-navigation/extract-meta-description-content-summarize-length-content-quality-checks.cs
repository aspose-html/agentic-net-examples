// Extract all meta description content and summarize its length for content quality checks.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head>" +
                          "<meta name=\"description\" content=\"First description.\">" +
                          "<meta name=\"description\" content=\"Second description longer.\">" +
                          "</head><body></body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection metas = document.GetElementsByTagName("meta");
                System.Collections.Generic.List<string> descriptions = new System.Collections.Generic.List<string>();

                for (int i = 0; i < metas.Length; i++)
                {
                    Aspose.Html.HTMLElement element = metas[i] as Aspose.Html.HTMLElement;
                    if (element != null)
                    {
                        string nameAttr = element.GetAttribute("name");
                        if (!string.IsNullOrEmpty(nameAttr) && nameAttr.Equals("description", StringComparison.OrdinalIgnoreCase))
                        {
                            string content = element.GetAttribute("content");
                            if (!string.IsNullOrEmpty(content))
                            {
                                descriptions.Add(content);
                            }
                        }
                    }
                }

                int totalLength = 0;
                for (int i = 0; i < descriptions.Count; i++)
                {
                    string desc = descriptions[i];
                    int len = desc.Length;
                    totalLength += len;
                    Console.WriteLine($"Description {i + 1}: \"{desc}\" (Length: {len})");
                }
                Console.WriteLine($"Total description length: {totalLength}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}