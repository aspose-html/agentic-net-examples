// Ensure every element has a unique ID by generating missing IDs based on tag names.

public class Program
{
    public static void Main()
    {
        try
        {
            string htmlContent = "<html><body><div></div><p id='p1'></p><span></span></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Collections.HTMLCollection elements = document.GetElementsByTagName("*");
            System.Collections.Generic.HashSet<string> existingIds = new System.Collections.Generic.HashSet<string>();
            System.Collections.Generic.Dictionary<string, int> tagCounters = new System.Collections.Generic.Dictionary<string, int>();
            for (int i = 0; i < elements.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)elements[i];
                string id = element.GetAttribute("id");
                if (!string.IsNullOrEmpty(id))
                {
                    existingIds.Add(id);
                    continue;
                }
                string tag = element.TagName.ToLowerInvariant();
                int count = 0;
                if (tagCounters.ContainsKey(tag))
                {
                    count = tagCounters[tag] + 1;
                    tagCounters[tag] = count;
                }
                else
                {
                    count = 1;
                    tagCounters[tag] = count;
                }
                string newId = $"{tag}_{count}";
                while (existingIds.Contains(newId))
                {
                    count++;
                    newId = $"{tag}_{count}";
                }
                element.SetAttribute("id", newId);
                existingIds.Add(newId);
            }
            System.Console.WriteLine(document.Body.OuterHTML);
        }
        catch (System.Exception ex)
        {
            System.Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}