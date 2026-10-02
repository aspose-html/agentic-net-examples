// Convert an EPUB to XPS using EpubRenderer and XpsDevice while specifying 1‑inch page margins.

class Program
{
    static void Main()
    {
        try
        {
            using (System.IO.Stream stream = System.IO.File.OpenRead("sample.epub"))
            {
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromInches(8.5),
                        Aspose.Html.Drawing.Length.FromInches(11)),
                    new Aspose.Html.Drawing.Margin(
                        Aspose.Html.Drawing.Length.FromInches(1),
                        Aspose.Html.Drawing.Length.FromInches(1),
                        Aspose.Html.Drawing.Length.FromInches(1),
                        Aspose.Html.Drawing.Length.FromInches(1)));
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, "output.xps");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}