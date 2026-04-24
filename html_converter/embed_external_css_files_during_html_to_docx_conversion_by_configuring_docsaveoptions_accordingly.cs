// Embed external CSS files during HTML to DOCX conversion by configuring DocSaveOptions accordingly.

using System;
using System.IO;
using System.Reflection;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.docx";

            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            PropertyInfo embedProp = options.GetType().GetProperty("EmbedExternalResources");
            if (embedProp != null && embedProp.PropertyType == typeof(bool))
            {
                embedProp.SetValue(options, true);
            }

            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, outputPath);

            Console.WriteLine("HTML to DOCX conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}