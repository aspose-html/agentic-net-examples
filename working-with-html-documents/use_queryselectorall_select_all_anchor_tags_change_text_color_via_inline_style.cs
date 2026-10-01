// Use QuerySelectorAll to select all anchor tags and change their text color via inline style.

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<html><body><a href=\"#\">Link1</a><a href=\"#\">Link2</a></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("a");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                element.SetAttribute("style", "color: red;");
            }
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}