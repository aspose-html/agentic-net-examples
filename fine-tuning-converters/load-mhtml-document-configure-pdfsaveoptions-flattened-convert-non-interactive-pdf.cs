// Load an MHTML document, configure PdfSaveOptions to Flattened, and convert it to a non‑interactive PDF.

namespace AsposeHtmlMhtmlToPdfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sourcePath = "sample.mhtml";
                string resultPath = "output.pdf";

                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions
                {
                    FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened
                };

                Aspose.Html.Converters.Converter.ConvertMHTML(sourcePath, options, resultPath);

                System.Console.WriteLine("MHTML has been successfully converted to a flattened PDF.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}