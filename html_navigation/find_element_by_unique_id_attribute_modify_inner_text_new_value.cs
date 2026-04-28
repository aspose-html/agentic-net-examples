// Find an element by its unique ID attribute and modify its inner text to a new value.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();
            string html = "<html><body><p id='myElement'>Old Text</p></body></html>";
            document.Write(html);
            var element = document.GetElementById("myElement");
            if (element != null)
            {
                element.InnerHTML = "New Text";
            }
            string outputPath = "output.html";
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}