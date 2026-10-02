// Create a CSS selector that targets the first paragraph element in the document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><p>First paragraph</p><p>Second paragraph</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Dom.Element element = document.QuerySelector("p");
            element.SetAttribute("style", "color:rgb(50,150,200); background-color:#e1f0fe;");
            document.Save("output.html");
            Console.WriteLine("First paragraph styled and document saved to output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}