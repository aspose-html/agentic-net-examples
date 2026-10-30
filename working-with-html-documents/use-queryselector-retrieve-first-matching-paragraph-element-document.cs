// Use QuerySelector to retrieve the first matching paragraph element in the document.

public class Program
{
    public static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p><p>Second paragraph</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Dom.Element element = document.QuerySelector("p");
            if (element != null)
            {
                element.SetAttribute("style", "color:rgb(50,150,200); background-color:#e1f0fe;");
            }
            string outputPath = "output.html";
            document.Save(outputPath);
            System.Console.WriteLine("Document saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}