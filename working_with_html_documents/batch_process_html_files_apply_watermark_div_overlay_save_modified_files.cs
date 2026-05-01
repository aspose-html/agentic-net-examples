// Batch process HTML files, apply a watermark div overlay, and save each modified file.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output");
            System.IO.Directory.CreateDirectory(outputDir);
            string[] inputs = new string[] { "input1.html", "input2.html" };
            for (int i = 0; i < inputs.Length; i++)
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputs[i], ""))
                {
                    Aspose.Html.Dom.Element div = document.CreateElement("div");
                    div.SetAttribute("style", "position:absolute;top:10px;left:10px;color:red;font-size:48px;opacity:0.5;");
                    div.TextContent = "Watermark";
                    document.Body.AppendChild(div);
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    string outputPath = System.IO.Path.Combine(outputDir, string.Format("output_{0}.jpeg", i));
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}