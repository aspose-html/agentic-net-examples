// Convert a list of HTML sources to MHTML outputs using MHTMLSaveOptions within a foreach loop.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            var htmlSources = new List<string>
            {
                "input1.html",
                "input2.html"
            };

            foreach (var sourcePath in htmlSources)
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);
                Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();
                string outputPath = Path.ChangeExtension(sourcePath, ".mht");
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}