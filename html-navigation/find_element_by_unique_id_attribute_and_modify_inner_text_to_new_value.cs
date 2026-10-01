// Find an element by its unique ID attribute and modify its inner text to a new value.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p id=\"myId\">Old text</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("", htmlContent);
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("#myId");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                element.InnerHTML = "New text";
            }
            string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);
            System.Console.WriteLine("Document saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}