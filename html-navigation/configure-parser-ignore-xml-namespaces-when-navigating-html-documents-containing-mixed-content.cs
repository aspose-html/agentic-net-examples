// Configure the parser to ignore XML namespaces when navigating HTML documents containing mixed content.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html xmlns:svg='http://www.w3.org/2000/svg'><body><svg:rect width='100' height='100' fill='red'/></body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection elements = document.GetElementsByTagName("rect");
                for (int i = 0; i < elements.Length; i++)
                {
                    Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)elements[i];
                    System.Console.WriteLine(element.TagName);
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}