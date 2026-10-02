// Find an element by its unique ID attribute and modify its inner text to a new value.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p id='myId'>Old text</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            var elements = document.QuerySelectorAll("#myId");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                element.InnerHTML = "New text";
                break;
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