// Clone a navigation menu element and insert the clone at the end of the body.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><title>Sample</title></head><body><nav id='main'><ul><li>Home</li><li>About</li></ul></nav></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");

            Aspose.Html.HTMLElement nav = (Aspose.Html.HTMLElement)System.Linq.Enumerable.First(document.GetElementsByTagName("nav"));
            Aspose.Html.HTMLElement clone = (Aspose.Html.HTMLElement)document.CreateElement("nav");
            clone.InnerHTML = nav.InnerHTML;
            clone.SetAttribute("id", "mainClone");

            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)System.Linq.Enumerable.First(document.GetElementsByTagName("body"));
            body.AppendChild(clone);

            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            document.Save("output.html", options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}