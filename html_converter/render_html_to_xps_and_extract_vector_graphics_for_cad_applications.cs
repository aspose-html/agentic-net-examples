// Render HTML to XPS and then extract vector graphics for use in CAD applications.

using System;
using System.IO;
using System.IO.Packaging;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string xpsPath = "output.xps";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, xpsPath);

            string outputDir = "ExtractedGraphics";
            Directory.CreateDirectory(outputDir);

            using (Package package = Package.Open(xpsPath, FileMode.Open, FileAccess.Read))
            {
                foreach (PackagePart part in package.GetParts())
                {
                    if (part.Uri.OriginalString.EndsWith(".fpage", StringComparison.OrdinalIgnoreCase))
                    {
                        string fileName = Path.GetFileName(part.Uri.OriginalString);
                        string destPath = Path.Combine(outputDir, fileName);
                        using (FileStream fs = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                        {
                            part.GetStream().CopyTo(fs);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}