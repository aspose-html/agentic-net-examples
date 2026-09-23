// Create a CSS -aspose- rule that adds a background color to all canvas elements in the PDF.

public class Program
{
    public static void Main()
    {
        try
        {
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLElement style = (Aspose.Html.HTMLElement)document.CreateElement("style");
            style.InnerHTML = "canvas { background-color: #FF0000; }";
            document.Body.AppendChild(style);

            string outputPath = "output.pdf";
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}