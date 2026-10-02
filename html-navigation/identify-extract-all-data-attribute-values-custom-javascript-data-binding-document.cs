// Identify and extract all data‑attribute values for custom JavaScript data binding in the document.

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath,
                    "<html><body><div data-id='123' data-name='Test'>Hello</div><span data-info='abc'></span></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            var elements = document.QuerySelectorAll("*");
            for (int i = 0; i < elements.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)elements[i];
                var attributeNames = element.GetAttributeNames();
                foreach (var name in attributeNames)
                {
                    if (name.StartsWith("data-"))
                    {
                        string value = element.GetAttribute(name);
                        if (!string.IsNullOrEmpty(value))
                        {
                            System.Console.WriteLine($"{name} = {value}");
                        }
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}