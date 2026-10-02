// Configure sandbox to allow images but block scripts, load a page, and confirm images display correctly.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string htmlContent = "<html><body><img id='testImg' src='data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+XK6cAAAAASUVORK5CYII=' /></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Images;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                Aspose.Html.Dom.Element element = document.GetElementById("testImg");
                string src = element != null ? element.GetAttribute("src") : null;
                System.Console.WriteLine("Image src attribute: " + src);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}