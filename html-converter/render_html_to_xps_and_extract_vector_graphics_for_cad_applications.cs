// Render HTML to XPS and then extract vector graphics for use in CAD applications.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string sourcePath = "sample.html";
                string outputPath = "output.xps";

                if (!System.IO.File.Exists(sourcePath))
                {
                    System.IO.File.WriteAllText(sourcePath, "<!DOCTYPE html><html><body><h1>Sample</h1><svg width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"green\" stroke-width=\"4\" fill=\"yellow\" /></svg></body></html>");
                }

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath))
                {
                    Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                    options.BackgroundColor = System.Drawing.Color.AliceBlue;

                    Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                        new Aspose.Html.Drawing.Size(
                            Aspose.Html.Drawing.Length.FromInches(8.5),
                            Aspose.Html.Drawing.Length.FromInches(11)),
                        new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

                    options.PageSetup.AnyPage = page;

                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }

                System.Console.WriteLine("HTML has been rendered to XPS: " + outputPath);
                // The generated XPS file contains vector graphics suitable for CAD applications.
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}