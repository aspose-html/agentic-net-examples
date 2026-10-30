// Create a document, add a link element referencing a stylesheet, and ensure stylesheet loads on render.

using System;

public class Program
{
    public static void Main()
    {
        try
        {
            // Prepare file paths
            string baseDir = System.IO.Directory.GetCurrentDirectory();
            string htmlPath = System.IO.Path.Combine(baseDir, "sample.html");
            string cssPath = System.IO.Path.Combine(baseDir, "style.css");
            string outputPath = System.IO.Path.Combine(baseDir, "output.png");

            // Create a simple stylesheet
            string cssContent = ".box { width:100px; height:100px; background-color:red; }";
            System.IO.File.WriteAllText(cssPath, cssContent);

            // Create an HTML document and add a link to the stylesheet
            string htmlTemplate = "<!DOCTYPE html><html><head></head><body></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlTemplate, "about:blank");

            // <link rel="stylesheet" href="style.css">
            Aspose.Html.Dom.Element link = document.CreateElement("link");
            link.SetAttribute("rel", "stylesheet");
            link.SetAttribute("href", "style.css");
            Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head")[0];
            head.AppendChild(link);

            // <div class="box"></div>
            Aspose.Html.Dom.Element div = document.CreateElement("div");
            div.SetAttribute("class", "box");
            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body")[0];
            body.AppendChild(div);

            // Save the HTML to a file
            document.Save(htmlPath);

            // Render the HTML (with stylesheet) to PNG
            Aspose.Html.Saving.ImageSaveOptions saveOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, saveOptions, outputPath);

            Console.WriteLine("Rendered image saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}