// Apply a background color style to the selected paragraph element.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><p>Hello World</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.HTMLElement paragraph = (Aspose.Html.HTMLElement)document.GetElementsByTagName("p")[0];
            paragraph.Style.BackgroundColor = "yellow";
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}