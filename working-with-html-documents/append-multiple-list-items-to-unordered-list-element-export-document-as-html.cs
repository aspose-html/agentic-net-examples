// Append multiple list items to an unordered list element, then export the document as HTML.

class Program
{
    static void Main()
    {
        try
        {
            var document = new Aspose.Html.HTMLDocument();
            var body = document.Body;
            var ul = (Aspose.Html.HTMLElement)document.CreateElement("ul");
            body.AppendChild(ul);

            string[] items = new string[] { "First item", "Second item", "Third item" };
            foreach (var itemText in items)
            {
                var li = (Aspose.Html.HTMLElement)document.CreateElement("li");
                var textNode = document.CreateTextNode(itemText);
                li.AppendChild(textNode);
                ul.AppendChild(li);
            }

            string outputPath = "output.html";
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}