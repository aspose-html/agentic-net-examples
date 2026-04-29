// Configure XpsSaveOptions to embed fonts within the XPS output for consistent rendering across devices.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                var document = new HTMLDocument("input.html");
                var options = new XpsSaveOptions();
                Converter.ConvertHTML(document, options, "output.xps");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}