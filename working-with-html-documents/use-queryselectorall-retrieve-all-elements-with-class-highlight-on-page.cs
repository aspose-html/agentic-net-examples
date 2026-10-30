// Use QuerySelectorAll to retrieve all elements with class "highlight" on the page.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p class='highlight'>First highlighted paragraph.</p><div class='highlight'>Second highlighted div.</div><span>Regular span.</span></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            var elements = document.QuerySelectorAll(".highlight");
            for (int i = 0; i < elements.Length; i++)
            {
                var element = elements[i] as Aspose.Html.HTMLElement;
                if (element != null)
                {
                    Console.WriteLine(element.InnerHTML);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}