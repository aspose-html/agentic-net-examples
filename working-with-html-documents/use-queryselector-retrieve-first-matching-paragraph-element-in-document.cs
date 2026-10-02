// Use QuerySelector to retrieve the first matching paragraph element in the document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>Hello World</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Dom.Element paragraph = document.QuerySelector("p");
            if (paragraph != null)
            {
                paragraph.SetAttribute("style", "color:rgb(50,150,200); background-color:#e1f0fe;");
            }
            document.Save("output.html");
            Console.WriteLine("Document saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}